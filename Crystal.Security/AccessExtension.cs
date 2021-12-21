﻿using System;
using static Crystal.PInvoke.AdvApi32;
using Crystal.PInvoke;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace Crystal.Extensions
{
	/// <summary>Extension methods for native and .NET access control objects.</summary>
	public static class AccessExtension
	{
		/// <summary>Converts a PSECURITY_DESCRIPTOR to a byte array.</summary>
		/// <param name="securityDescriptor">The security descriptor.</param>
		/// <returns>The byte array of the PSECURITY_DESCRIPTOR.</returns>
		public static byte[] ToByteArray(this PSECURITY_DESCRIPTOR securityDescriptor)
		{
			var sdLength = GetSecurityDescriptorLength(securityDescriptor);
			var buffer = new byte[sdLength];
			Marshal.Copy((IntPtr)securityDescriptor, buffer, 0, (int)sdLength);
			return buffer;
		}

		/// <summary>Converts a PSECURITY_DESCRIPTOR to a managed RawSecurityDescriptor.</summary>
		/// <param name="securityDescriptor">The security descriptor.</param>
		/// <returns>The RawSecurityDescriptor.</returns>
		public static RawSecurityDescriptor ToManaged(this PSECURITY_DESCRIPTOR securityDescriptor) => new RawSecurityDescriptor(securityDescriptor.ToByteArray(), 0);

		/// <summary>Converts a RawSecurityDescriptor to a native safe handle.</summary>
		/// <param name="rawSD">The RawSecurityDescriptor.</param>
		/// <returns>A native safe handle for PSECURITY_DESCRIPTOR.</returns>
		public static SafePSECURITY_DESCRIPTOR ToNative(this RawSecurityDescriptor rawSD) => new SafePSECURITY_DESCRIPTOR(rawSD.ToByteArray());

		/// <summary>Converts a RawSecurityDescriptor to a byte array.</summary>
		/// <param name="rawSD">The RawSecurityDescriptor.</param>
		/// <returns>A byte array.</returns>
		public static byte[] ToByteArray(this RawSecurityDescriptor rawSD)
		{
			var buffer = new byte[rawSD.BinaryLength];
			rawSD.GetBinaryForm(buffer, 0);
			return buffer;
		}
	}
}