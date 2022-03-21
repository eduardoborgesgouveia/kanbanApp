using KanbanApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApp.Filters
{
    public class LogFilter : IActionFilter
    {

        private readonly ApiContext _context;
        private Cards currentCard { get; set; }

        public LogFilter(ApiContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Buscar o card que será alterado/removido
            object obId;
            context.RouteData.Values.TryGetValue("id", out obId);
            if (obId != null)
            {
                string id = obId.ToString();
                currentCard = _context.Cards.FirstOrDefault(s => s.id.ToString() == id);

            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Realizar o registro do log
            if (context.Result.GetType() == typeof(OkObjectResult) && currentCard != null)
            {
                HttpRequest req = context.HttpContext.Request;
                string methodType = req.Method == "PUT" ? "Alterar" : "Remover";
                string log_string = string.Format("{0} - Card {1} - {2} - {3}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), currentCard.id, currentCard.titulo, methodType);
                System.Diagnostics.Debug.WriteLine(log_string);
            }
        }
    }
}
