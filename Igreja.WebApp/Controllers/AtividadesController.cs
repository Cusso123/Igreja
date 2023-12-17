using Igreja.Dados;
using Igreja.Dominio.Entidades;
using Igreja.Dominio.Servicos;
using Igreja.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Igreja.WebApp.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly IAtividadeService _AtividadeService;

        public AtividadesController(IAtividadeService AtividadeService)
        {
            _AtividadeService = AtividadeService;
        }
        public IActionResult Index()
        {
            var resultado = _AtividadeService.GetAll();
            return View(resultado);
        }
        public IActionResult CadastroAtv()
        {
            
            return View(new AtividadesViewModel());
        }

        [HttpGet]
        public IActionResult EditarAtv(int AtividadeID)
        {

            Atividades editarAtv = _AtividadeService.GetOneById(AtividadeID);

            if (AtividadeID == null || AtividadeID == 0)
            {
                throw new Exception("Não há dados dessa Atividade");
            }

            if (editarAtv == null)
            {
                return NotFound();
            }

            AtividadesViewModel editarAtividadesModel = new AtividadesViewModel
            {
                Descricao = editarAtv.Descricao,
                DataAtividade = editarAtv.DataAtividade,
                AtividadeID = editarAtv.AtividadeID,
                AtividadeNome = editarAtv.AtividadeNome
                
            };

            return View(editarAtividadesModel);
        }
        public IActionResult CadastrarAtividade(AtividadesViewModel atv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Atividades Atividade = new()
                    {
                        Descricao = atv.Descricao,
                        DataAtividade = atv.DataAtividade,
                        AtividadeID = atv.AtividadeID,
                        AtividadeNome = atv.AtividadeNome
                    };
                    _AtividadeService.CadastrarAtividade(Atividade);
                    TempData["MensagemSucesso"] = "Atividade cadastrada com sucesso";
                    return RedirectToAction("CadastroAtv");
                }
                return View("CadastroAtv", atv);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao cadastrar a Atividade, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("CadastroAtv", atv);
            }
        }

        public IActionResult ApagarA(int AtividadedID)
        {
            Atividades apagaratv = _AtividadeService.BuscarPorID(AtividadedID);
            return View(apagaratv);

        }
        public IActionResult ApagarAtividade(int AtividadedID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _AtividadeService.ApagarAtividade(AtividadedID);
                    TempData["MensagemSucesso"] = "Atividade apagada com sucesso";
                    return RedirectToAction("Index");
                }

                return View(CadastroAtv);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em apagar a Atividade, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult EditarAtividade(AtividadesViewModel Atividade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Atividades atv = new()
                    {
                        Descricao = Atividade.Descricao,
                        DataAtividade = Atividade.DataAtividade,
                        AtividadeID = Atividade.AtividadeID,
                        AtividadeNome = Atividade.AtividadeNome
                    };
                    _AtividadeService.EditarAtividade(atv);
                    TempData["MensagemSucesso"] = "Cadastro editado com sucesso";
                    return RedirectToAction("Index");

                }
                return View("EditarAtv", Atividade);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar a Atividade, tente novamente, erro: {erro.Message}";
                return RedirectToAction("EditarAtv");
            }
        }
    }
}
