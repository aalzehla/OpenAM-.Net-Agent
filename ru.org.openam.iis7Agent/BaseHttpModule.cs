﻿using System.Web;

namespace ru.org.openam.iis7Agent
{
	public class BaseHttpModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			context.BeginRequest += (sender, e) => OnBeginRequest(new HttpContextWrapper(((HttpApplication) sender).Context));
			context.AuthenticateRequest += (sender, e) => OnAuthentication(new HttpContextWrapper(((HttpApplication) sender).Context));
			context.EndRequest += (sender, e) => OnEndRequest(new HttpContextWrapper(((HttpApplication) sender).Context));
		}

		public void Dispose()
		{
		}

		public virtual void OnBeginRequest(HttpContextBase context)
		{
		}

		public virtual void OnAuthentication(HttpContextBase context)
		{
		}

		public virtual void OnEndRequest(HttpContextBase context)
		{
		}
 
		public virtual void CompleteRequest(HttpContextBase context){
			context.ApplicationInstance.CompleteRequest();
		}
	}
}