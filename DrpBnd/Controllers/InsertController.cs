using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrpBnd.Models;
namespace DrpBnd.Controllers
{
    public class InsertController : Controller
    {
        DrpBindEntities dbobj = new DrpBindEntities();
        SDBind obj = new SDBind();
        // GET: Insert
        public ActionResult Insert_Load()
        {
            List<stclass> stList = obj.Selectstates();
            ViewBag.Selstates = new SelectList(stList, "sId", "sName");
            return View();
        }
        private List<SelectListItem> GetDisbyStid(int StateId)
        {
            var getdis = obj.SelectDis(StateId);
            var disbysts = getdis.Select(a => new SelectListItem() 
            { Value = a.DId.ToString(), Text = a.DName }).ToList();
            return disbysts;
        }
        public JsonResult GetDist(int StateId)
        {
            var dis = GetDisbyStid(StateId);
            return Json(dis, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Insert_Click(Insert clsobj, FormCollection form)
        {
            if(ModelState.IsValid)
            { 
            List<stclass> stlist = obj.Selectstates();
            int SelectId = Convert.ToInt32(form["stId"]);//same as table
                stclass selectedItem = stlist.FirstOrDefault(c => c.sId == SelectId);
            clsobj.sId = selectedItem.sId;
            clsobj.sName = selectedItem.sName;

                int disId = Convert.ToInt32(form["DisId"]);//same as table
                clsobj.DId = disId;
                ViewBag.Selstates = new SelectList(stlist, "sId", "sName");

                dbobj.sp_Insert(clsobj.sId, clsobj.DId, clsobj.Name, clsobj.Age,clsobj.Address);
                clsobj.Msg = "Successfully Inserted";
                return View("Insert_Load", clsobj);
            }
            else
            {
                List<stclass> stList = obj.Selectstates();
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");
            }
            return View("Insert_Load",clsobj);
        }
    }
}