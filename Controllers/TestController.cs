using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
namespace MVC_Test2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index(int pageIndex = 1, int pageSize = 5)
        {
            PageList<Student> list = StudentManager.PageListDemo(pageIndex, pageSize);
            //将数据传递到视图
            ViewBag.li = list.DataList;
            //保存当前的页码
            ViewBag.index = pageIndex;
            //保存总页数
            ViewBag.count = list.PageCount;
            return View();
        }
        //gengxinfuwuqiASASASAS
        public ActionResult Del(int id)
        {
            //调用删除方法
            int result = StudentManager.Del(id);
            return RedirectToAction("Index");
        }
        //跳转到添加视图
        public ActionResult Create()
        {
            ViewBag.depts = DeptManager.GetDept();
            return View();//跳转到添加视图
        }

        public ActionResult Add(Student s)
        {
            //调用添加方法
            int result = StudentManager.Add(s);
            if (result > 0)
            {
                return Content("<script>alert('新增成功');location.href='/Test/Index'</script>");
            }
            else
            {
                return Content("<script>alert('新增失败');</script>");

            }
            //return RedirectToAction("Index");
        }
        //跳转到编辑视图
        public ActionResult Update(int id)
        {
            ViewBag.depts = DeptManager.GetDept();
            ViewBag.stu = StudentManager.GetById(id);
            return View();
        }
        public ActionResult Edit(Student s)
        {
            //调用修改方法
            int result = StudentManager.Edit(s);
            return RedirectToAction("Index");
        }

        //跳转至Disp编辑视图
        public ActionResult Disp()
        {
            return View();
        }
    }
}