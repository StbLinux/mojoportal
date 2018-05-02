﻿// Author:					
// Created:					2010-12-09
// Last Modified:			2018-05-02
// 
// The use and distribution terms for this software are covered by the 
// Common Public License 1.0 (http://opensource.org/licenses/cpl.php)  
// which can be found in the file CPL.TXT at the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by 
// the terms of this license.
//
// You must not remove this notice, or any other, from this software.

using System;
using mojoPortal.Business.WebHelpers;
using Resources;


namespace mojoPortal.Web.AdminUI
{

    public partial class DesignerToolsPage : NonCmsBasePage
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((!WebUser.IsInRoles(siteSettings.RolesThatCanManageSkins))) 
            {
                SiteUtils.RedirectToAccessDeniedPage(this);
                return;
            }

            PopulateLabels();
            
        }
        
        private void PopulateLabels()
        {
            Title = SiteUtils.FormatPageTitle(siteSettings, DevTools.DesignTools);

            heading.Text = DevTools.DesignTools;

            lnkAdminMenu.Text = Resource.AdminMenuLink;
            lnkAdminMenu.NavigateUrl = SiteRoot + "/Admin/AdminMenu.aspx";

            lnkThisPage.Text = DevTools.DesignTools;
            lnkThisPage.NavigateUrl = SiteRoot + "/DesignTools/Default.aspx";

            lnkSkinList.Text = DevTools.SkinManagement;
            lnkSkinList.NavigateUrl = SiteRoot + "/DesignTools/SkinList.aspx";

            lnkCacheTool.Text = DevTools.CacheTool;
            lnkCacheTool.NavigateUrl = SiteRoot + "/DesignTools/CacheTool.aspx";

            AddClassToBody("administration");
            AddClassToBody("designtools");
        }

        #region OnInit

        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(this.Page_Load);
            

            SuppressMenuSelection();
            SuppressPageMenu();

        }

        

        #endregion
    }
}
