// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#import "..\\ClassLibrary1\\bin\\Debug\\ClassLibrary1.tlb" no_namespace named_guids

INT _tmain(INT argc, _TCHAR *argv[])
{
	CoInitialize(NULL);
	{
		HRESULT hr;

		IClass1Ptr sp;
		if (SUCCEEDED(hr = sp.CreateInstance(__uuidof(Class1))))
		{
			sp->Ping();
		}
		else
		{
			_tprintf(_T("IClass1Ptr::CreateInstance(): %s\n"), _com_error(hr).ErrorMessage());
		}
	}
	CoUninitialize();

	return 0;
}
