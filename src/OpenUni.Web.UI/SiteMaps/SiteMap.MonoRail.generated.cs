//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenUni.Web.UI.SiteMap {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootDepartmentsControllerActionNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootDepartmentsControllerActionNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerActionReference Index() {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "", "Departments", "Index", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "Index", new System.Type[0]), new Castle.Tools.CodeGenerator.External.ActionArgument[0]);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerActionReference Show(string departmentName) {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "", "Departments", "Show", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "Show", new System.Type[] {
                            typeof(string)}), new Castle.Tools.CodeGenerator.External.ActionArgument[] {
                        new Castle.Tools.CodeGenerator.External.ActionArgument(0, "departmentName", typeof(string), departmentName)});
        }
        
        // Empty argument Action... Not sure if we want to pass MethodInformation to these...
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IArgumentlessControllerActionReference Show() {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "", "Departments", "Show", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "Show", new System.Type[] {
                            typeof(string)}), new Castle.Tools.CodeGenerator.External.ActionArgument[0]);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootHomeControllerActionNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootHomeControllerActionNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerActionReference Index() {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.HomeController), "", "Home", "Index", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.HomeController), "Index", new System.Type[0]), new Castle.Tools.CodeGenerator.External.ActionArgument[0]);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerActionReference About() {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.HomeController), "", "Home", "About", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.HomeController), "About", new System.Type[0]), new Castle.Tools.CodeGenerator.External.ActionArgument[0]);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootSqlLogControllerActionNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootSqlLogControllerActionNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerActionReference View(int requestId) {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.SqlLogController), "", "SqlLog", "View", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.SqlLogController), "View", new System.Type[] {
                            typeof(int)}), new Castle.Tools.CodeGenerator.External.ActionArgument[] {
                        new Castle.Tools.CodeGenerator.External.ActionArgument(0, "requestId", typeof(int), requestId)});
        }
        
        // Empty argument Action... Not sure if we want to pass MethodInformation to these...
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IArgumentlessControllerActionReference View() {
            return this._services.ControllerReferenceFactory.CreateActionReference(this._services, typeof(OpenUni.Web.UI.Controllers.SqlLogController), "", "SqlLog", "View", new Castle.Tools.CodeGenerator.External.MethodSignature(typeof(OpenUni.Web.UI.Controllers.SqlLogController), "View", new System.Type[] {
                            typeof(int)}), new Castle.Tools.CodeGenerator.External.ActionArgument[0]);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootDepartmentsControllerRouteNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootDepartmentsControllerRouteNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RouteDefinitions {
        
        /// <summary>
        /// departments
        /// </summary>
        public static DepartmentsRoute Departments {
            get {
                return new DepartmentsRoute();
            }
        }
        
        /// <summary>
        /// department/&lt;departmentName:string&gt;
        /// </summary>
        public static DepartmentRoute Department {
            get {
                return ((DepartmentRoute)(new DepartmentRoute().DefaultForArea().Is("").DefaultForController().Is<OpenUni.Web.UI.Controllers.DepartmentsController>().DefaultForAction().Is("Show")));
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static HomepageRoute Homepage {
            get {
                return new HomepageRoute();
            }
        }
        
        /// <summary>
        /// about
        /// </summary>
        public static aboutRoute about {
            get {
                return new aboutRoute();
            }
        }
        
        /// <summary>
        /// sql-log/&lt;requestId:number&gt;
        /// </summary>
        public static SqlLogRoute SqlLog {
            get {
                return ((SqlLogRoute)(new SqlLogRoute().DefaultForArea().Is("").DefaultForController().Is<OpenUni.Web.UI.Controllers.SqlLogController>().DefaultForAction().Is("View")));
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
        public partial class DepartmentsRoute : Castle.Tools.CodeGenerator.External.StaticRoute {
            
            public DepartmentsRoute() : 
                    base("Departments", "departments", "", "Departments", "Index") {
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
        public partial class DepartmentRoute : Castle.MonoRail.Framework.Routing.PatternRoute {
            
            public DepartmentRoute() : 
                    base("Department", "department/<departmentName>") {
            }
            
            [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
            public partial class RequiredParameters {
            }
            
            [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
            public partial class OptionalParameters {
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
        public partial class HomepageRoute : Castle.Tools.CodeGenerator.External.StaticRoute {
            
            public HomepageRoute() : 
                    base("Homepage", "", "", "Home", "Index") {
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
        public partial class aboutRoute : Castle.Tools.CodeGenerator.External.StaticRoute {
            
            public aboutRoute() : 
                    base("about", "about", "", "Home", "About") {
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
        public partial class SqlLogRoute : Castle.MonoRail.Framework.Routing.PatternRoute {
            
            public SqlLogRoute() : 
                    base("SqlLog", "sql-log/<requestId>") {
            }
            
            [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
            public partial class RequiredParameters {
            }
            
            [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
            public partial class OptionalParameters {
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class Routes {
        
        protected Castle.MonoRail.Framework.IEngineContext engineContext;
        
        public Routes(Castle.MonoRail.Framework.IEngineContext engineContext) {
            this.engineContext = engineContext;
        }
        
        /// <summary>
        /// departments
        /// </summary>
        public virtual string Departments() {
            return RouteDefinitions.Departments.CreateUrl(null);
        }
        
        /// <summary>
        /// department/&lt;departmentName:string&gt;
        /// </summary>
        public virtual string Department() {
            System.Collections.IDictionary routeParameters = Castle.MonoRail.Framework.Helpers.DictHelper.Create();
            return RouteDefinitions.Department.CreateUrl(routeParameters);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual string Homepage() {
            return RouteDefinitions.Homepage.CreateUrl(null);
        }
        
        /// <summary>
        /// about
        /// </summary>
        public virtual string about() {
            return RouteDefinitions.about.CreateUrl(null);
        }
        
        /// <summary>
        /// sql-log/&lt;requestId:number&gt;
        /// </summary>
        public virtual string SqlLog() {
            System.Collections.IDictionary routeParameters = Castle.MonoRail.Framework.Helpers.DictHelper.Create();
            return RouteDefinitions.SqlLog.CreateUrl(routeParameters);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootHomeControllerRouteNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootHomeControllerRouteNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootSqlLogControllerRouteNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootSqlLogControllerRouteNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootDepartmentsControllerViewNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootDepartmentsControllerViewNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerViewReference Index {
            get {
                return this._services.ControllerReferenceFactory.CreateViewReference(this._services, typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "", "Departments", "Index");
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerViewReference Show {
            get {
                return this._services.ControllerReferenceFactory.CreateViewReference(this._services, typeof(OpenUni.Web.UI.Controllers.DepartmentsController), "", "Departments", "Show");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootHomeControllerViewNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootHomeControllerViewNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerViewReference About {
            get {
                return this._services.ControllerReferenceFactory.CreateViewReference(this._services, typeof(OpenUni.Web.UI.Controllers.HomeController), "", "Home", "About");
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerViewReference Index {
            get {
                return this._services.ControllerReferenceFactory.CreateViewReference(this._services, typeof(OpenUni.Web.UI.Controllers.HomeController), "", "Home", "Index");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootSqlLogControllerViewNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        public RootSqlLogControllerViewNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual Castle.Tools.CodeGenerator.External.IControllerViewReference View {
            get {
                return this._services.ControllerReferenceFactory.CreateViewReference(this._services, typeof(OpenUni.Web.UI.Controllers.SqlLogController), "", "SqlLog", "View");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootAreaNode {
        
        protected Castle.Tools.CodeGenerator.External.ICodeGeneratorServices _services;
        
        private RootDepartmentsControllerNode _departments;
        
        private RootHomeControllerNode _home;
        
        private RootSqlLogControllerNode _sqlLog;
        
        public RootAreaNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) {
            this._services = services;
            this._departments = new RootDepartmentsControllerNode(this._services);
            this._home = new RootHomeControllerNode(this._services);
            this._sqlLog = new RootSqlLogControllerNode(this._services);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootDepartmentsControllerNode Departments {
            get {
                return this._departments;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootHomeControllerNode Home {
            get {
                return this._home;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootSqlLogControllerNode SqlLog {
            get {
                return this._sqlLog;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootDepartmentsControllerNode : RootDepartmentsControllerActionNode {
        
        public RootDepartmentsControllerNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) : 
                base(services) {
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootDepartmentsControllerViewNode Views {
            get {
                return new RootDepartmentsControllerViewNode(this._services);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootDepartmentsControllerActionNode Actions {
            get {
                return this;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootHomeControllerNode : RootHomeControllerActionNode {
        
        public RootHomeControllerNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) : 
                base(services) {
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootHomeControllerViewNode Views {
            get {
                return new RootHomeControllerViewNode(this._services);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootHomeControllerActionNode Actions {
            get {
                return this;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class RootSqlLogControllerNode : RootSqlLogControllerActionNode {
        
        public RootSqlLogControllerNode(Castle.Tools.CodeGenerator.External.ICodeGeneratorServices services) : 
                base(services) {
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootSqlLogControllerViewNode Views {
            get {
                return new RootSqlLogControllerViewNode(this._services);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual RootSqlLogControllerActionNode Actions {
            get {
                return this;
            }
        }
    }
}
namespace OpenUni.Web.UI.Controllers {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class DepartmentsController {
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootDepartmentsControllerNode MyActions {
            get {
                return new OpenUni.Web.UI.SiteMap.RootDepartmentsControllerNode(this.CodeGeneratorServices);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootDepartmentsControllerViewNode MyViews {
            get {
                return new OpenUni.Web.UI.SiteMap.RootDepartmentsControllerViewNode(this.CodeGeneratorServices);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootDepartmentsControllerRouteNode MyRoutes {
            get {
                return new OpenUni.Web.UI.SiteMap.RootDepartmentsControllerRouteNode(this.CodeGeneratorServices);
            }
        }
        
        protected override void PerformGeneratedInitialize() {
            base.PerformGeneratedInitialize();
            this.PropertyBag["MyViews"] = this.MyViews;
            this.PropertyBag["MyActions"] = this.MyActions;
            this.PropertyBag["MyRoutes"] = this.MyRoutes;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class HomeController {
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootHomeControllerNode MyActions {
            get {
                return new OpenUni.Web.UI.SiteMap.RootHomeControllerNode(this.CodeGeneratorServices);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootHomeControllerViewNode MyViews {
            get {
                return new OpenUni.Web.UI.SiteMap.RootHomeControllerViewNode(this.CodeGeneratorServices);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootHomeControllerRouteNode MyRoutes {
            get {
                return new OpenUni.Web.UI.SiteMap.RootHomeControllerRouteNode(this.CodeGeneratorServices);
            }
        }
        
        protected override void PerformGeneratedInitialize() {
            base.PerformGeneratedInitialize();
            this.PropertyBag["MyViews"] = this.MyViews;
            this.PropertyBag["MyActions"] = this.MyActions;
            this.PropertyBag["MyRoutes"] = this.MyRoutes;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Castle.Tools.CodeGenerator", "0.2")]
    public partial class SqlLogController {
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootSqlLogControllerNode MyActions {
            get {
                return new OpenUni.Web.UI.SiteMap.RootSqlLogControllerNode(this.CodeGeneratorServices);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootSqlLogControllerViewNode MyViews {
            get {
                return new OpenUni.Web.UI.SiteMap.RootSqlLogControllerViewNode(this.CodeGeneratorServices);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public virtual OpenUni.Web.UI.SiteMap.RootSqlLogControllerRouteNode MyRoutes {
            get {
                return new OpenUni.Web.UI.SiteMap.RootSqlLogControllerRouteNode(this.CodeGeneratorServices);
            }
        }
        
        protected override void PerformGeneratedInitialize() {
            base.PerformGeneratedInitialize();
            this.PropertyBag["MyViews"] = this.MyViews;
            this.PropertyBag["MyActions"] = this.MyActions;
            this.PropertyBag["MyRoutes"] = this.MyRoutes;
        }
    }
}
