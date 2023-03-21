﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHocThem
{
    public partial class TuyenDung : System.Web.UI.Page
    {
        WebHocThemDataContext context = new WebHocThemDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Login.aspx?url=" + Request.Url.AbsolutePath);
                return;
            }

            try
            {
                var user = context.AspNetUserRoles.First(x => x.UserId == User.Identity.GetUserName());
                if (user.RoleId == 1 || user.RoleId == 2)
                {
                    ucTuyenDung.Listv(true);
                    //Response.Write("<script>javascript:alert('Hãy nâng cấp tài khoản và thử lại !');window.location.href='Default.aspx';</script>");                    
                }
                else Response.Write("<script>javascript:alert('Chức năng này chỉ dành cho giảng viên !');</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>javascript:alert('Chức năng này chỉ dành cho giảng viên !');</script>");
            }
        }
    }
}