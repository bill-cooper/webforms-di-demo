﻿using System;
using System.Reflection;
using System.Web.Hosting;

namespace di_demo.Tests.Server
{
    internal class HostingEnvironmentWrapper
    {

        private static readonly HostingEnvironmentWrapper _Instance;

        private readonly HostingEnvironment _Inner;
        private readonly Type _Type = typeof(HostingEnvironment);
        private readonly TestVirtualPathProvider _VirtualPathProvider = new TestVirtualPathProvider();


        static HostingEnvironmentWrapper()
        {

            _Instance = new HostingEnvironmentWrapper(new object());

        }

        /// <summary>
        /// Do nothing
        /// </summary>
        public HostingEnvironmentWrapper() { }

        private HostingEnvironmentWrapper(object stub)
        {

            _Inner = new HostingEnvironment();

            Configure();

        }

        private void Configure()
        {

            var fi = _Type.GetField("_appVirtualPath", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(_Inner, VirtualPathWrapper.Create("/").VirtualPath);

            fi = _Type.GetField("_configMapPath", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(_Inner, new TestConfigMapPath());

            fi = _Type.GetField("_virtualPathProvider", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(_Inner, _VirtualPathProvider);

        }

        public static implicit operator HostingEnvironment(HostingEnvironmentWrapper wrapper)
        {

            return HostingEnvironmentWrapper._Instance._Inner;

        }

    }
}
