﻿using System.Web;
using System.Web.Optimization;

namespace BugTrackerV2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/font-sb").Include(
                     "~/Content/all.min.css",
                     "~/Content/sb-admin-2.min.css"));

            bundles.Add(new StyleBundle("~/Content/data-tables").Include(
                     "~/Content/dataTables.bootstrap4.css",
                     "~/Content/dataTables.bootstrap4.min.css"));
            //
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-core").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/core-plugin").Include(
                      "~/Scripts/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom-all").Include(
                      "~/Scripts/sb-admin-2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/data-tables").Include(
                            "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/datatables-demo.js",
                        "~/Scripts/dataTables.bootstrap4.js",
                        "~/Scripts/dataTables.bootstrap4.min.js"));
        }
    }
}