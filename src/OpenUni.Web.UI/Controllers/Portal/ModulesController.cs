using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MonoRail.Framework;
using Castle.Tools.CodeGenerator.External;

using OpenUni.Domain.Modules;
using OpenUni.Domain.People;
using OpenUni.Web.UI.Filters;
using OpenUni.Web.UI.Views.Layouts;

namespace OpenUni.Web.UI.Controllers.Portal
{
	public class ModuleChooseInfo
	{
		public int Id { get; set;}
		public string Name { get; set;}
		public int Capacity { get; set;}
		public int AlreadyRegistered { get; set;}
	}
	[ControllerDetails(Area = "Portal")]
	[Layout(Layouts.XHTML, Layouts.PORTAL)]
	[StudentsOnly]
	public partial class ModulesController : AbstractController
	{
		readonly IModulesRepository modulesRepository;

		public ModulesController(IModulesRepository modulesRepository)
		{
			this.modulesRepository = modulesRepository;
		}

		public void MyModules()
		{
			var person = Session["Person"] as Person;
			PropertyBag["MyModules"] = modulesRepository.AllFor(person);
		}

        public void Register()
        {
        	var today = DateTime.Today;
        	var nextTerm = GetNext(GetTerm(today));
        	var year = nextTerm.Key;
			var term = nextTerm.Value;
			
			var person = Session["Person"] as Person;
			PropertyBag["Modules"] = modulesRepository.AllFor(year, term).Select(o=>new ModuleChooseInfo{Id=(int)o[0],
																										 Name = (string)o[1],
																										 Capacity = (int)o[2],
																										 AlreadyRegistered = (int)o[3],
			});
        	PropertyBag["Year"] = year;
        	PropertyBag["Term"] = term;
        	PropertyBag["TermString"] = GetTermString(year, term);
		}

		private string GetTermString(int year, byte term)
		{
			return "" + year + (char)('א' + (term - 1));
		}

		KeyValuePair<int, byte> GetNext(KeyValuePair<int, byte> current)
		{
			if (current.Value < 3)
				return new KeyValuePair<int, byte>(current.Key, (byte) (current.Value + 1));
			return new KeyValuePair<int, byte>(current.Key+1, 1);
		}

		KeyValuePair<int, byte> GetTerm(DateTime date)
		{
			var year = date.Year;
			byte term = 1;
			if (date.Month>9)
			{
				year += 1;
			}
			else
			{
				if (date.Month>6)
					term = 3;
				else
				{
					term = 2;
				}
			}
			return new KeyValuePair<int, byte>(year, term);
		}

	}
}