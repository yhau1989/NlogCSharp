using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace WebSite
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                example();
            }
        }



        protected void example()
        {
            MakeLog log = new Tools.MakeLog();
            DateTime time_start = DateTime.Now;

            log.writeLog_info("Message start program", "AppName");

            log.writeLog_trace("Message start program 2", "AppName");
            try
            {
                int g = Convert.ToInt32("sdasda");
            }
            catch (Exception ex)
            {

                log.writeLog_error(ex, "error Message program", "AppName");
            }

            DateTime time_end = DateTime.Now;
            TimeSpan ts = time_end - time_start;
            log.writeLog_trace("End execution program", "AppName", null, null, ts.ToString(@"hh\:mm\:ss\.fff"));

        }
    }
}