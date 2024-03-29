﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class MakeLog
    {


        private int nivelLog;
        private Logger logger = null;

        public int NivelLog
        {
            get
            {
                return nivelLog;
            }

            set
            {
                nivelLog = value;
            }
        }

        public MakeLog()
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["NoLog"].ToString() == "1")
                {
                    nivelLog = 1;
                }

                if (System.Configuration.ConfigurationManager.AppSettings["SoftLog"].ToString() == "1")
                {
                    nivelLog = 2;
                }

                if (System.Configuration.ConfigurationManager.AppSettings["HeavyLog"].ToString() == "1")
                {
                    nivelLog = 3;
                }
            }
            catch (Exception ex)
            {

                nivelLog = 0;
            }
        }

        /// <summary>
                        /// Método para escribir logs en la base de datos con Nlog
                        /// </summary>
                        /// <param name="mensaje">mensaje personalizado del error</param>
                        /// <param name="app">aplicación donde se produjo el error</param>
                        /// <param name="DataInput"></param>
                        /// <param name="DataOutput"></param>
                        /// <param name="TimeProces"></param>
        public void writeLog_info(string mensaje, string app, string DataInput = null, string DataOutput = null, string TimeProces = null, string processRecord = null, string validarError = null)
        {

            if (nivelLog > 0)
            {
                logger = LogManager.GetCurrentClassLogger();
                GlobalDiagnosticsContext.Set("App", app);
                if (DataInput != null) { GlobalDiagnosticsContext.Set("DataInput", DataInput); } else { GlobalDiagnosticsContext.Set("DataInput", ""); }
                if (DataOutput != null) { GlobalDiagnosticsContext.Set("DataOutput", DataOutput); } else { GlobalDiagnosticsContext.Set("DataOutput", ""); }
                if (TimeProces != null) { GlobalDiagnosticsContext.Set("TimeProces", TimeProces); } else { GlobalDiagnosticsContext.Set("TimeProces", ""); }
                if (processRecord != null) { GlobalDiagnosticsContext.Set("ProcessedRecords", processRecord); } else { GlobalDiagnosticsContext.Set("ProcessedRecords", ""); }
                if (validarError != null)
                {
                    GlobalDiagnosticsContext.Set("ValidarError", 1);
                    logger.Error(mensaje);
                }
                else
                {
                    GlobalDiagnosticsContext.Set("ValidarError", "");
                    logger.Info(mensaje);
                }

            }

        }

        /// <summary>
                        /// Método para escribir logs en la base de datos con Nlog
                        /// </summary>
                        /// <param name="mensaje">mensaje personalizado del error</param>
                        /// <param name="app">aplicación donde se produjo el error</param>
                        /// <param name="DataInput"></param>
                        /// <param name="DataOutput"></param>
                        /// <param name="TimeProces"></param>
        public void writeLog_trace(string mensaje, string app, string DataInput = null, string DataOutput = null, string TimeProces = null, string processRecord = null, string validarError = null)
        {

            if (nivelLog == 2 || nivelLog == 3)
            {
                logger = LogManager.GetCurrentClassLogger();
                GlobalDiagnosticsContext.Set("App", app);
                if (DataInput != null) { GlobalDiagnosticsContext.Set("DataInput", DataInput); } else { GlobalDiagnosticsContext.Set("DataInput", ""); }
                if (DataOutput != null) { GlobalDiagnosticsContext.Set("DataOutput", DataOutput); } else { GlobalDiagnosticsContext.Set("DataOutput", ""); }
                if (TimeProces != null) { GlobalDiagnosticsContext.Set("TimeProces", TimeProces); } else { GlobalDiagnosticsContext.Set("TimeProces", ""); }
                if (processRecord != null) { GlobalDiagnosticsContext.Set("ProcessedRecords", processRecord); } else { GlobalDiagnosticsContext.Set("ProcessedRecords", ""); }
                if (validarError != null)
                {
                    GlobalDiagnosticsContext.Set("ValidarError", 1);
                    logger.Error(mensaje);
                }
                else
                {
                    GlobalDiagnosticsContext.Set("ValidarError", "");
                    logger.Trace(mensaje);
                }
            }
        }


        /// <summary>
                        /// Método para escribir logs en la base de datos con Nlog
                        /// </summary>
                        /// <param name="error" type="Exception">Exception  del error</param>
                        /// <param name="mensaje">mensaje personalizado del error</param>
                        /// <param name="app">aplicación donde se produjo el error</param>
                        /// <param name="DataInput"></param>
                        /// <param name="DataOutput"></param>
                        /// <param name="TimeProces"></param>
        public void writeLog_error(Exception error, string mensaje, string app, string DataInput = null, string DataOutput = null, string TimeProces = null, string processRecord = null)
        {
            logger = LogManager.GetCurrentClassLogger();
            GlobalDiagnosticsContext.Set("App", app);
            if (DataInput != null) { GlobalDiagnosticsContext.Set("DataInput", DataInput); } else { GlobalDiagnosticsContext.Set("DataInput", ""); }
            if (DataOutput != null) { GlobalDiagnosticsContext.Set("DataOutput", DataOutput); } else { GlobalDiagnosticsContext.Set("DataOutput", ""); }
            if (TimeProces != null) { GlobalDiagnosticsContext.Set("TimeProces", TimeProces); } else { GlobalDiagnosticsContext.Set("TimeProces", ""); }
            if (processRecord != null) { GlobalDiagnosticsContext.Set("ProcessedRecords", processRecord); } else { GlobalDiagnosticsContext.Set("ProcessedRecords", ""); }
            GlobalDiagnosticsContext.Set("ValidarError", 1);
            logger.Error(error, mensaje);
        }
    }
}
