using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksApp.Models;

namespace BooksApp.Controllers
{
    public class BookController : Controller
    {
       // public static List<Book> list = new List<Book>();
        DAO dao;
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Book book)
        {
             dao = new DAO();
            int count = 0;
            if (ModelState.IsValid)
            {
                //list.Add(book);
                count = dao.Insert(book);
                if (count == 1)
                {
                    ViewData["message"] = "Record inserted succesfully";
                }
                else
                {
                    ViewData["message"] = dao.message;
                }
                 return View("../Home/Index");
            }
            else return View("Index", book);

            }
       

        public ActionResult ShowBooks()
        {
            dao = new DAO();
            List<Book> list = dao.ShowAll();
            return View(list);
        }
    }
}