using System;
using System.Reflection;
using Castle.Components.Binder;
using Castle.MonoRail.Framework;

namespace OpenUni.Web.UI.Attributes
{
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class BindFromAttribute : Attribute, IParameterBinder
	{
		private readonly string parameterName;
		private readonly IDataBinder binder = new DataBinder();

		public BindFromAttribute(string parameterName)
		{
			if (string.IsNullOrEmpty(parameterName))
			{
				throw new ArgumentException("parameterName must not be null or empty", "parameterName");
			}
			this.parameterName = parameterName;
		}

		public string ParameterName
		{
			get { return parameterName; }
		}

		/// <summary>
		///             Calculates the param points. Implementers should return value equals or greater than
		///             zero indicating whether the parameter can be bound successfully. The greater the value (points)
		///             the more successful the implementation indicates to the framework
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="controller">The controller.</param>
		/// <param name="controllerContext">The controller context.</param>
		/// <param name="parameterInfo">The parameter info.</param>
		/// <returns>
		/// </returns>
		public int CalculateParamPoints(IEngineContext context, IController controller, IControllerContext controllerContext, ParameterInfo parameterInfo)
		{
			var token = context.Request[parameterName];
			if (CanConvert(parameterInfo.ParameterType, token)) 
				return 10;
			return 0;
		}

		static bool CanConvert(Type targetType, string token)
		{
			if (token == null)
				return false;

			try
			{
				Convert.ChangeType(token, targetType);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Binds the specified parameters for the action.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="controller">The controller.</param>
		/// <param name="controllerContext">The controller context.</param>
		/// <param name="parameterInfo">The parameter info.</param>
		/// <returns>
		/// </returns>
		public object Bind(IEngineContext context, IController controller, IControllerContext controllerContext, ParameterInfo parameterInfo)
		{
			var token = context.Request[parameterName];
			if (CanConvert(parameterInfo.ParameterType, token) == false)
				return null;

			return Convert.ChangeType(token, parameterInfo.ParameterType);
		}
	}
}