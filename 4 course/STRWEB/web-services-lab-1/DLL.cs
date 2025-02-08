using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace lab1
{
    public class DLL : IHttpHandler, IRequiresSessionState
    {
        // Начальное значение RESULT
        private static int result = 0;

        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            // Инициализация стека в сессии, если он не был создан ранее
            if (context.Session["stackSession"] == null)
                context.Session["stackSession"] = new Stack<int>();

            Stack<int> stack = context.Session["stackSession"] as Stack<int>;

            // Получаем метод запроса
            string requestType = context.Request.HttpMethod;

            // Определяем логику обработки в зависимости от метода
            switch (requestType)
            {
                case "GET":
                    // Возвращаем JSON с текущим значением result и вершиной стека (если она существует)
                    context.Response.ContentType = "application/json";
                    if (stack.Count == 0)
                    {
                        context.Response.Write("{\"result\": " + result + "}");
                    }
                    else
                    {
                        context.Response.Write("{\"result\": " + (result + stack.Peek()) + "}");
                    }
                    break;

                case "POST":
                    // Изменяем значение result на переданное значение RESULT
                    if (context.Request.QueryString["RESULT"] != null)
                    {
                        result = Convert.ToInt32(context.Request.QueryString["RESULT"]);
                    }
                    else
                    {
                        context.Response.StatusCode = 400; // Ошибка, если параметр отсутствует
                        context.Response.Write("Parameter 'RESULT' is required.");
                    }
                    break;

                case "PUT":
                    // Выполняем PUSH операции для стека, добавляем значение из параметра ADD
                    if (context.Request.QueryString["ADD"] != null)
                    {
                        int add = Convert.ToInt32(context.Request.QueryString["ADD"]);
                        stack.Push(add);
                    }
                    else
                    {
                        context.Response.StatusCode = 400; // Ошибка, если параметр отсутствует
                        context.Response.Write("Parameter 'ADD' is required.");
                    }
                    break;

                case "DELETE":
                    // Выполняем POP операции для стека
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        context.Response.StatusCode = 400; // Ошибка, если стек пуст
                        context.Response.Write("Stack is empty.");
                    }
                    break;

                default:
                    // Метод не поддерживается
                    context.Response.StatusCode = 405;
                    context.Response.Write("Method Not Allowed");
                    break;
            }
        }

    }
}
