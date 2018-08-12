using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using DevExpress.Web;
using System.IO;

    namespace Decision 
    {
        public class Global_asax : System.Web.HttpApplication 
        {
            void Application_Start(object sender, EventArgs e) 
            {
                DevExpress.Web.BinaryStorageConfigurator.Mode = DevExpress.Web.BinaryStorageMode.Session;
                DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);
                DevExpress.Data.Helpers.SecurityHelper.ForcePartialTrustMode = true;
            }

            void Application_End(object sender, EventArgs e) 
            {
                // Code that runs on application shutdown
            }

            void Application_Error(object sender, EventArgs e) 
            {
                //// Code that runs when an unhandled error occurs

                //// Get the exception object.
                //Exception exc = Server.GetLastError();

                //// Handle HTTP errors
                //if (exc.GetType() == typeof(HttpException))
                //{
                //    // The Complete Error Handling Example generates
                //    // some errors using URLs with "NoCatch" in them;
                //    // ignore these here to simulate what would happen
                //    // if a global.asax handler were not implemented.
                //    if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                //        return;

                //    //Redirect HTTP errors to HttpError page
                //    Server.Transfer("HttpErrorPage.aspx");
                //}

                //// For other kinds of errors give the user some information
                //// but stay on the default page
                //Response.Write("<h2>Global Page Error</h2>\n");
                //Response.Write("<p>" + exc.Message + "</p>\n");
                //Response.Write("Return to the <a href='Default.aspx'>Default Page</a>\n");

                //// Log the exception and notify system operators
                //ExceptionUtility.LogException(exc, "DefaultPage");
                //ExceptionUtility.NotifySystemOps(exc);

                //// Clear the error from the server
                //Server.ClearError();

                // Use HttpContext.Current to get a Web request processing helper 
                HttpServerUtility server = HttpContext.Current.Server;
                Exception exception = server.GetLastError();
            }

            void Session_Start(object sender, EventArgs e) 
            {
                // Code that runs when a new session is started
            }

            void Session_End(object sender, EventArgs e) 
            {
                // Code that runs when a session ends. 
                // Note: The Session_End event is raised only when the sessionstate mode
                // is set to InProc in the Web.config file. If session mode is set to StateServer 
                // or SQLServer, the event is not raised.
            }
        }

        // Create our own utility for exceptions 
        public sealed class ExceptionUtility
        {
            // All methods are static, so this can be private 
            private ExceptionUtility()
            { }

            // Log an Exception 
            public static void LogException(Exception exc, string source)
            {
                // Include enterprise logic for logging exceptions 
                // Get the absolute path to the log file 
                string logFile = "App_Data/ErrorLog.txt";
                logFile = HttpContext.Current.Server.MapPath(logFile);

                // Open the log file for append and write the log
                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine("********** {0} **********", DateTime.Now);
                if (exc.InnerException != null)
                {
                    sw.Write("Inner Exception Type: ");
                    sw.WriteLine(exc.InnerException.GetType().ToString());
                    sw.Write("Inner Exception: ");
                    sw.WriteLine(exc.InnerException.Message);
                    sw.Write("Inner Source: ");
                    sw.WriteLine(exc.InnerException.Source);
                    if (exc.InnerException.StackTrace != null)
                    {
                        sw.WriteLine("Inner Stack Trace: ");
                        sw.WriteLine(exc.InnerException.StackTrace);
                    }
                }
                sw.Write("Exception Type: ");
                sw.WriteLine(exc.GetType().ToString());
                sw.WriteLine("Exception: " + exc.Message);
                sw.WriteLine("Source: " + source);
                sw.WriteLine("Stack Trace: ");
                if (exc.StackTrace != null)
                {
                    sw.WriteLine(exc.StackTrace);
                    sw.WriteLine();
                }
                sw.Close();
            }

            // Notify System Operators about an exception 
            public static void NotifySystemOps(Exception exc)
            {
                // Include code for notifying IT system operators
            }
        }
    }