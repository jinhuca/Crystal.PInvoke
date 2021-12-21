﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Crystal.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// <para>Exposes methods that enable clients to access items in a collection of objects that support IUnknown.</para>
		/// </summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>Clients do not need to implement this interface.</para>
		/// <para>When to Use</para>
		/// <para>Use this interface to access generic objects in an array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objectarray/nn-objectarray-iobjectarray
		[PInvokeData("objectarray.h", MSDNShortId = "ab0bb213-dc9c-4853-98d7-668e7ca76583")]
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
		public interface IObjectArray
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			uint GetCount();

			/// <summary>
			/// Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.
			/// </summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetAt([In] uint uiIndex, in Guid riid);
		}

		/// <summary>
		/// <para>
		/// Extends the IObjectArray interface by providing methods that enable clients to add and remove objects that support IUnknown in a collection.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>When to Use</para>
		/// <para>Use this interface to interact with a collection of generic objects.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objectarray/nn-objectarray-iobjectcollection
		[PInvokeData("objectarray.h", MSDNShortId = "d7665b26-5839-4b08-a099-ef25a68c65db")]
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5632b1a4-e38a-400a-928a-d4cd63230295"), CoClass(typeof(CEnumerableObjectCollection))]
		public interface IObjectCollection : IObjectArray
		{
			/// <summary>Provides a count of the objects in the collection.</summary>
			/// <returns>The number of objects in the collection.</returns>
			new uint GetCount();

			/// <summary>
			/// Provides a pointer to a specified object's interface. The object and interface are specified by index and interface ID.
			/// </summary>
			/// <param name="uiIndex">The index of the object</param>
			/// <param name="riid">Reference to the desired interface ID.</param>
			/// <returns>Receives the interface pointer requested in riid.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetAt([In] uint uiIndex, in Guid riid);

			/// <summary>Adds a single object to the collection.</summary>
			/// <param name="punk">Pointer to the IUnknown of the object to be added to the collection.</param>
			void AddObject([In, MarshalAs(UnmanagedType.IUnknown)] object punk);

			/// <summary>Adds the objects contained in an IObjectArray to the collection.</summary>
			/// <param name="poaSource">Pointer to the IObjectArray whose contents are to be added to the collection.</param>
			void AddFromArray(IObjectArray poaSource);

			/// <summary>Removes a single, specified object from the collection.</summary>
			/// <param name="uiIndex">A pointer to the index of the object within the collection.</param>
			void RemoveObjectAt(uint uiIndex);

			/// <summary>Removes all objects from the collection.</summary>
			void Clear();
		}

		/// <summary>Extension method to simplify using the <see cref="IObjectArray.GetAt(uint, in Guid)"/> method.</summary>
		/// <typeparam name="T">Type of the interface to get.</typeparam>
		/// <param name="a">An <see cref="IObjectArray"/> instance.</param>
		/// <param name="uiIndex">The index of the object</param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public static T GetAt<T>(this IObjectArray a, uint uiIndex) where T : class => (T)a.GetAt(uiIndex, typeof(T).GUID);

		/// <summary>Extension method to convert an <see cref="IObjectArray"/> instance to an array of <typeparamref name="T"/>.</summary>
		/// <typeparam name="T">Type of the interface to get. Supplying a type <see cref="object"/> will get the <c>IUnknown</c> reference.</typeparam>
		/// <param name="a">An <see cref="IObjectArray"/> instance.</param>
		/// <returns>An array of <typeparamref name="T"/>.</returns>
		public static T[] ToArray<T>(this IObjectArray a) where T : class
		{
			const string IID_IUnknown = "00000000-0000-0000-C000-000000000046";
			var gIUnk = typeof(T) == typeof(object) ? new Guid(IID_IUnknown) : typeof(T).GUID;
			var c = a.GetCount();
			var ret = new T[c];
			for (var i = 0U; i < c; i++)
				ret[i] = (T)a.GetAt(i, gIUnk);
			return ret;
		}
	}
}