using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Seguranca
{
    public class PermissaoFiltro : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult)
                filterContext.HttpContext.Response.Redirect("/Usuario/Login");

        }

    }
}