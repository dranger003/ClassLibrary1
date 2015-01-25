﻿using System;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    //MIDL_INTERFACE("A1230207-d6a7-11d8-b9fd-000bdbd1f198")
    //IWTSVirtualChannel : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Write( 
    //        /* [in] */ ULONG cbSize,
    //        /* [size_is][in] */ __RPC__in_ecount_full(cbSize) BYTE *pBuffer,
    //        /* [in] */ __RPC__in_opt IUnknown *pReserved) = 0;
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Close( void) = 0;
    //};
    [ComImport]
    [Guid("A1230207-d6a7-11d8-b9fd-000bdbd1f198")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWTSVirtualChannel
    {
        void Write(
            [In] UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPArray)]
            [In] Byte pBuffer,
            [MarshalAs(UnmanagedType.IUnknown)]
            [In] Object pReserved);
        void Close();
    }

    //MIDL_INTERFACE("A1230204-d6a7-11d8-b9fd-000bdbd1f198")
    //IWTSVirtualChannelCallback : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE OnDataReceived( 
    //        /* [in] */ ULONG cbSize,
    //        /* [size_is][in] */ __RPC__in_ecount_full(cbSize) BYTE *pBuffer) = 0;
        
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE OnClose( void) = 0;
    //};
    [ComImport]
    [Guid("A1230204-d6a7-11d8-b9fd-000bdbd1f198")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWTSVirtualChannelCallback
    {
        void OnDataReceived(
            [In] UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPArray)]
            [In] Byte pBuffer);
        void OnClose();
    }

    //MIDL_INTERFACE("A1230206-9a39-4d58-8674-cdb4dff4e73b")
    //IWTSListener : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE GetConfiguration( 
    //        /* [out] */ __RPC__deref_out_opt IPropertyBag **ppPropertyBag) = 0;
    //};
    [ComImport]
    [Guid("A1230206-9a39-4d58-8674-cdb4dff4e73b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWTSListener
    {
        void GetConfiguration( 
            [MarshalAs(UnmanagedType.IUnknown)]
            [Out] Object ppPropertyBag);
    }

    //MIDL_INTERFACE("A1230203-d6a7-11d8-b9fd-000bdbd1f198")
    //IWTSListenerCallback : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE OnNewChannelConnection( 
    //        /* [in] */ __RPC__in_opt IWTSVirtualChannel *pChannel,
    //        /* [full][in] */ __RPC__in_opt BSTR data,
    //        /* [out] */ __RPC__out BOOL *pbAccept,
    //        /* [out] */ __RPC__deref_out_opt IWTSVirtualChannelCallback **ppCallback) = 0;
    //};
    [ComImport]
    [Guid("A1230203-d6a7-11d8-b9fd-000bdbd1f198")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWTSListenerCallback
    {
        void OnNewChannelConnection(
            [MarshalAs(UnmanagedType.Interface)]
            [In] IWTSVirtualChannel pChannel,
            [MarshalAs(UnmanagedType.BStr)]
            [In] String data,
            [Out] out Boolean pbAccept,
            [MarshalAs(UnmanagedType.Interface)]
            [Out] out IWTSVirtualChannelCallback ppCallback);
    }

    //MIDL_INTERFACE("A1230205-d6a7-11d8-b9fd-000bdbd1f198")
    //IWTSVirtualChannelManager : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE CreateListener( 
    //        /* [string][in] */ __RPC__in_string const char *pszChannelName,
    //        /* [in] */ ULONG uFlags,
    //        /* [in] */ __RPC__in_opt IWTSListenerCallback *pListenerCallback,
    //        /* [out] */ __RPC__deref_out_opt IWTSListener **ppListener) = 0;
    //};
    [ComImport]
    [Guid("A1230205-d6a7-11d8-b9fd-000bdbd1f198")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWTSVirtualChannelManager
    {
        void CreateListener(
            [MarshalAs(UnmanagedType.LPStr)]
            [In] String pszChannelName,
            [In] UInt32 uFlags,
            [MarshalAs(UnmanagedType.Interface)]
            [In] IWTSListenerCallback pListenerCallback,
            [MarshalAs(UnmanagedType.Interface)]
            [In, Out] ref IWTSListener ppListener);
    }

    //MIDL_INTERFACE("A1230201-1439-4e62-a414-190d0ac3d40e")
    //IWTSPlugin : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Initialize( 
    //        /* [in] */ __RPC__in_opt IWTSVirtualChannelManager *pChannelMgr) = 0;
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Connected( void) = 0;
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Disconnected( 
    //        DWORD dwDisconnectCode) = 0;
    //    virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE Terminated( void) = 0;
    //};
    [ComImport]
    [Guid("A1230201-1439-4e62-a414-190d0ac3d40e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWTSPlugin
    {
        void Initialize(
            [MarshalAs(UnmanagedType.Interface)]
            [In] IWTSVirtualChannelManager pChannelMgr);
        void Connected();
        void Disconnected(
            [In] UInt32 dwDisconnectCode);
        void Terminated();
    }

    [Guid("3EE167D4-16DC-48B6-B5A0-22E142266F73")]
    public interface IClass1
    {
        void Ping();
    }

    // Class1
    //
    [Guid("D5633330-784B-4A82-93B4-DBDC4A86A128")]
    public class Class1 : IClass1, IWTSPlugin, IWTSListenerCallback
    {
        // IClass1
        //
        public void Ping()
        {
            System.Diagnostics.Debug.WriteLine("Class1.Ping()");
        }

        // IWTSPlugin
        //
        public void Initialize(IWTSVirtualChannelManager manager)
        {
            System.Diagnostics.Debug.WriteLine("Class1.Initialize()");

            IWTSListener listener = null;
            manager.CreateListener(
                "Channel1",
                0,
                this,
                ref listener);
        }

        public void Connected()
        {
            System.Diagnostics.Debug.WriteLine("Class1.Connected()");
        }

        public void Disconnected(uint code)
        {
            System.Diagnostics.Debug.WriteLine("Class1.Disconnected()");
        }

        public void Terminated()
        {
            System.Diagnostics.Debug.WriteLine("Class1.Terminated()");
        }

        // IWTSListenerCallback
        //
        public void OnNewChannelConnection(
            IWTSVirtualChannel pChannel,
            string data,
            out bool pbAccept,
            out IWTSVirtualChannelCallback ppCallback)
        {
            pbAccept = false;
            ppCallback = null;

            System.Diagnostics.Debug.WriteLine("Class1.OnNewChannelConnection()");
        }
    }
}
