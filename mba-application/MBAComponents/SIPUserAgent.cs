using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using VAXSIPUSERAGENTCOMLib;
using System.Windows;

namespace mba_application.MBAComponents
{
    public class SIPUserAgent
    {
        private VaxVoIPSIP mba_objVaxVoIP;

        public SIPUserAgent()
        {
            mba_objVaxVoIP = new VaxVoIPSIP();
            mba_objVaxVoIP.OnFailToTransfer += new _IVaxVoIPSIPEvents_OnFailToTransferEventHandler(OnFailToTransfer);
            mba_objVaxVoIP.OnTryingToRegister += new _IVaxVoIPSIPEvents_OnTryingToRegisterEventHandler(OnTryingToRegister);
            mba_objVaxVoIP.OnFailToRegister += new _IVaxVoIPSIPEvents_OnFailToRegisterEventHandler(OnFailToRegister);
            mba_objVaxVoIP.OnFailToRegisterEx += new _IVaxVoIPSIPEvents_OnFailToRegisterExEventHandler(OnFailToRegisterEx);
            mba_objVaxVoIP.OnSuccessToRegister += new _IVaxVoIPSIPEvents_OnSuccessToRegisterEventHandler(OnSuccessToRegister);
            mba_objVaxVoIP.OnTryingToReRegister += new _IVaxVoIPSIPEvents_OnTryingToReRegisterEventHandler(OnTryingToReRegister);
            mba_objVaxVoIP.OnFailToReRegister += new _IVaxVoIPSIPEvents_OnFailToReRegisterEventHandler(OnFailToReRegister);
            mba_objVaxVoIP.OnFailToReRegisterEx += new _IVaxVoIPSIPEvents_OnFailToReRegisterExEventHandler(OnFailToReRegisterEx);
            mba_objVaxVoIP.OnSuccessToReRegister += new _IVaxVoIPSIPEvents_OnSuccessToReRegisterEventHandler(OnSuccessToReRegister);
            mba_objVaxVoIP.OnTryingToUnRegister += new _IVaxVoIPSIPEvents_OnTryingToUnRegisterEventHandler(OnTryingToUnRegister);
            mba_objVaxVoIP.OnFailToUnRegister += new _IVaxVoIPSIPEvents_OnFailToUnRegisterEventHandler(OnFailToUnRegister);
            mba_objVaxVoIP.OnSuccessToUnRegister += new _IVaxVoIPSIPEvents_OnSuccessToUnRegisterEventHandler(OnSuccessToUnRegister);
            mba_objVaxVoIP.OnConnecting += new _IVaxVoIPSIPEvents_OnConnectingEventHandler(OnConnecting);
            mba_objVaxVoIP.OnSuccessToConnect += new _IVaxVoIPSIPEvents_OnSuccessToConnectEventHandler(OnSuccessToConnect);
            mba_objVaxVoIP.OnFailToConnect += new _IVaxVoIPSIPEvents_OnFailToConnectEventHandler(OnFailToConnect);
            mba_objVaxVoIP.OnDisconnectCall += new _IVaxVoIPSIPEvents_OnDisconnectCallEventHandler(OnDisconnectCall);
            mba_objVaxVoIP.OnCallTransferAccepted += new _IVaxVoIPSIPEvents_OnCallTransferAcceptedEventHandler(OnCallTransferAccepted);
            mba_objVaxVoIP.OnPlayWaveDone += new _IVaxVoIPSIPEvents_OnPlayWaveDoneEventHandler(OnPlayWaveDone);
            mba_objVaxVoIP.OnDTMFDigit += new _IVaxVoIPSIPEvents_OnDTMFDigitEventHandler(OnDTMFDigit);
            mba_objVaxVoIP.OnMsgNOTIFY += new _IVaxVoIPSIPEvents_OnMsgNOTIFYEventHandler(OnMsgNOTIFY);
            mba_objVaxVoIP.OnVoiceMailMsg += new _IVaxVoIPSIPEvents_OnVoiceMailMsgEventHandler(OnVoiceMailMsg);
            mba_objVaxVoIP.OnIncomingCall += new _IVaxVoIPSIPEvents_OnIncomingCallEventHandler(OnIncomingCall);
            mba_objVaxVoIP.OnIncomingCallRingingStart += new _IVaxVoIPSIPEvents_OnIncomingCallRingingStartEventHandler(OnIncomingCallRingingStart);
            mba_objVaxVoIP.OnIncomingCallRingingStop += new _IVaxVoIPSIPEvents_OnIncomingCallRingingStopEventHandler(OnIncomingCallRingingStop);

            mba_objVaxVoIP.OnProvisionalResponse += new _IVaxVoIPSIPEvents_OnProvisionalResponseEventHandler(OnProvisionalResponse);
            mba_objVaxVoIP.OnRedirectionResponse += new _IVaxVoIPSIPEvents_OnRedirectionResponseEventHandler(OnRedirectionResponse);
            mba_objVaxVoIP.OnRequestFailureResponse += new _IVaxVoIPSIPEvents_OnRequestFailureResponseEventHandler(OnRequestFailureResponse);
            mba_objVaxVoIP.OnServerFailureResponse += new _IVaxVoIPSIPEvents_OnServerFailureResponseEventHandler(OnServerFailureResponse);
            mba_objVaxVoIP.OnGeneralFailureResponse += new _IVaxVoIPSIPEvents_OnGeneralFailureResponseEventHandler(OnGeneralFailureResponse);

            mba_objVaxVoIP.OnIncomingDiagnostic += new _IVaxVoIPSIPEvents_OnIncomingDiagnosticEventHandler(OnIncomingDiagnostic);
            mba_objVaxVoIP.OnOutgoingDiagnostic += new _IVaxVoIPSIPEvents_OnOutgoingDiagnosticEventHandler(OnOutgoingDiagnostic);

            mba_objVaxVoIP.OnSessionLostEvent += new _IVaxVoIPSIPEvents_OnSessionLostEventEventHandler(OnSessionLostEvent);

            mba_objVaxVoIP.OnSuccessToHold += new _IVaxVoIPSIPEvents_OnSuccessToHoldEventHandler(OnSuccessToHold);
            mba_objVaxVoIP.OnTryingToHold += new _IVaxVoIPSIPEvents_OnTryingToHoldEventHandler(OnTryingToHold);
            mba_objVaxVoIP.OnFailToHold += new _IVaxVoIPSIPEvents_OnFailToHoldEventHandler(OnFailToHold);

            mba_objVaxVoIP.OnSuccessToUnHold += new _IVaxVoIPSIPEvents_OnSuccessToUnHoldEventHandler(OnSuccessToUnHold);
            mba_objVaxVoIP.OnTryingToUnHold += new _IVaxVoIPSIPEvents_OnTryingToUnHoldEventHandler(OnTryingToUnHold);
            mba_objVaxVoIP.OnFailToUnHold += new _IVaxVoIPSIPEvents_OnFailToUnHoldEventHandler(OnFailToUnHold);

            mba_objVaxVoIP.OnChatContactStatus += new _IVaxVoIPSIPEvents_OnChatContactStatusEventHandler(OnChatContactStatus);
            mba_objVaxVoIP.OnChatSendMsgTextSuccess += new _IVaxVoIPSIPEvents_OnChatSendMsgTextSuccessEventHandler(OnChatSendMsgTextSuccess);
            mba_objVaxVoIP.OnChatSendMsgTextFail += new _IVaxVoIPSIPEvents_OnChatSendMsgTextFailEventHandler(OnChatSendMsgTextFail);
            mba_objVaxVoIP.OnChatSendMsgTypingSuccess += new _IVaxVoIPSIPEvents_OnChatSendMsgTypingSuccessEventHandler(OnChatSendMsgTypingSuccess);
            mba_objVaxVoIP.OnChatSendMsgTypingFail += new _IVaxVoIPSIPEvents_OnChatSendMsgTypingFailEventHandler(OnChatSendMsgTypingFail);
            mba_objVaxVoIP.OnChatRecvMsgText += new _IVaxVoIPSIPEvents_OnChatRecvMsgTextEventHandler(OnChatRecvMsgText);

            mba_objVaxVoIP.OnChatRecvMsgTypingStart += new _IVaxVoIPSIPEvents_OnChatRecvMsgTypingStartEventHandler(OnChatRecvMsgTypingStart);
            mba_objVaxVoIP.OnChatRecvMsgTypingStop += new _IVaxVoIPSIPEvents_OnChatRecvMsgTypingStopEventHandler(OnChatRecvMsgTypingStop);
            mba_objVaxVoIP.OnVoiceStreamPCM += new _IVaxVoIPSIPEvents_OnVoiceStreamPCMEventHandler(OnVoiceStreamPCM);
            mba_objVaxVoIP.OnDetectedAMD += new _IVaxVoIPSIPEvents_OnDetectedAMDEventHandler(OnDetectedAMD);

            mba_objVaxVoIP.OnVideoRemoteShowStart += new _IVaxVoIPSIPEvents_OnVideoRemoteShowStartEventHandler(OnVideoRemoteShowStart);
            mba_objVaxVoIP.OnVideoRemoteShowStop += new _IVaxVoIPSIPEvents_OnVideoRemoteShowStopEventHandler(OnVideoRemoteShowStop);

            mba_objVaxVoIP.OnVideoRemoteShowRGB += new _IVaxVoIPSIPEvents_OnVideoRemoteShowRGBEventHandler(OnVideoRemoteShowRGB);
            mba_objVaxVoIP.OnVideoDeviceShowRGB += new _IVaxVoIPSIPEvents_OnVideoDeviceShowRGBEventHandler(OnVideoDeviceShowRGB);

            mba_objVaxVoIP.OnTryingToRegisterREC += new _IVaxVoIPSIPEvents_OnTryingToRegisterRECEventHandler(OnTryingToRegisterREC);
            mba_objVaxVoIP.OnSuccessToRegisterREC += new _IVaxVoIPSIPEvents_OnSuccessToRegisterRECEventHandler(OnSuccessToRegisterREC);
            mba_objVaxVoIP.OnFailToRegisterREC += new _IVaxVoIPSIPEvents_OnFailToRegisterRECEventHandler(OnFailToRegisterREC);

            mba_objVaxVoIP.OnTryingToReRegisterREC += new _IVaxVoIPSIPEvents_OnTryingToReRegisterRECEventHandler(OnTryingToReRegisterREC);
            mba_objVaxVoIP.OnSuccessToReRegisterREC += new _IVaxVoIPSIPEvents_OnSuccessToReRegisterRECEventHandler(OnSuccessToReRegisterREC);
            mba_objVaxVoIP.OnFailToReRegisterREC += new _IVaxVoIPSIPEvents_OnFailToReRegisterRECEventHandler(OnFailToReRegisterREC);

            mba_objVaxVoIP.OnTryingToUnRegisterREC += new _IVaxVoIPSIPEvents_OnTryingToUnRegisterRECEventHandler(OnTryingToUnRegisterREC);
            mba_objVaxVoIP.OnSuccessToUnRegisterREC += new _IVaxVoIPSIPEvents_OnSuccessToUnRegisterRECEventHandler(OnSuccessToUnRegisterREC);
            mba_objVaxVoIP.OnFailToUnRegisterREC += new _IVaxVoIPSIPEvents_OnFailToUnRegisterRECEventHandler(OnFailToUnRegisterREC);

            mba_objVaxVoIP.OnServerConnectingREC += new _IVaxVoIPSIPEvents_OnServerConnectingRECEventHandler(OnServerConnectingREC);
            mba_objVaxVoIP.OnServerConnectedREC += new _IVaxVoIPSIPEvents_OnServerConnectedRECEventHandler(OnServerConnectedREC);
            mba_objVaxVoIP.OnServerFailedREC += new _IVaxVoIPSIPEvents_OnServerFailedRECEventHandler(OnServerFailedREC);
            mba_objVaxVoIP.OnServerHungupREC += new _IVaxVoIPSIPEvents_OnServerHungupRECEventHandler(OnServerHungupREC);
        }

        private void OnVideoRemoteShowStart(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnVideoRemoteShowStop(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnVideoRemoteShowRGB(int LineNo, ulong FrameRGB, int FrameSize, int FrameWidth, int FrameHeight)
        {
            throw new NotImplementedException();
        }

        private void OnVideoDeviceShowRGB(int DeviceId, ulong FrameRGB, int FrameSize, int FrameWidth, int FrameHeight)
        {
            throw new NotImplementedException();
        }

        private void OnTryingToRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnFailToRegisterREC(int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnTryingToReRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToReRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnFailToReRegisterREC(int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnTryingToUnRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToUnRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnFailToUnRegisterREC()
        {
            throw new NotImplementedException();
        }

        private void OnServerConnectingREC(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnServerConnectedREC(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnServerFailedREC(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnServerHungupREC(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnDetectedAMD(int LineNo, bool bIsHuman)
        {
            throw new NotImplementedException();
        }

        private void OnVoiceStreamPCM(int LineNo, int DataPCM, int SizePCM)
        {
            throw new NotImplementedException();
        }

        private void OnChatRecvMsgTypingStop(string UserName)
        {
            throw new NotImplementedException();
        }

        private void OnChatRecvMsgTypingStart(string UserName)
        {
            throw new NotImplementedException();
        }

        private void OnChatRecvMsgText(string UserName, string MsgText)
        {
            throw new NotImplementedException();
        }

        private void OnChatSendMsgTypingFail(string UserName, int StatusCode, string ReasonPhrase, int UserValue32bit)
        {
            throw new NotImplementedException();
        }

        private void OnChatSendMsgTypingSuccess(string UserName, int UserValue32bit)
        {
            throw new NotImplementedException();
        }

        private void OnChatSendMsgTextFail(string UserName, int StatusCode, string ReasonPhrase, string MsgText, int UserValue32bit)
        {
            throw new NotImplementedException();
        }

        private void OnChatSendMsgTextSuccess(string UserName, string MsgText, int UserValue32bit)
        {
            throw new NotImplementedException();
        }

        private void OnChatContactStatus(string UserName, int StatusId)
        {
            throw new NotImplementedException();
        }

        private void OnFailToUnHold(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnTryingToUnHold(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToUnHold(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnFailToHold(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnTryingToHold(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToHold(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnSessionLostEvent(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnOutgoingDiagnostic(string MsgSIP, string ToIP, int ToPort)
        {
            //throw new NotImplementedException();
        }

        private void OnIncomingDiagnostic(string MsgSIP, string FromIP, int FromPort)
        {
            //throw new NotImplementedException();
        }

        private void OnGeneralFailureResponse(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnServerFailureResponse(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnRequestFailureResponse(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnRedirectionResponse(int LineNo, int StatusCode, string ReasonPhrase, string Contact)
        {
            throw new NotImplementedException();
        }

        private void OnProvisionalResponse(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnIncomingCallRingingStop(string CallId)
        {
            throw new NotImplementedException();
        }

        private void OnIncomingCallRingingStart(string CallId)
        {
            throw new NotImplementedException();
        }

        private void OnIncomingCall(string CallId, string DisplayName, string UserName, string FromURI, string ToURI)
        {
            throw new NotImplementedException();
        }

        private void OnVoiceMailMsg(bool IsMsgWaiting, int NewMsgCount, int OldMsgCount, int NewUrgentMsgCount, int OldUrgentMsgCount, string MsgAccount)
        {
            throw new NotImplementedException();
        }

        private void OnMsgNOTIFY(string Msg)
        {
            throw new NotImplementedException();
        }

        private void OnDTMFDigit(int LineNo, string Digit)
        {
            throw new NotImplementedException();
        }

        private void OnPlayWaveDone(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnCallTransferAccepted(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnDisconnectCall(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnFailToConnect(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToConnect(int LineNo, string ToRTPIP, int ToRTPPort)
        {
            throw new NotImplementedException();
        }

        private void OnConnecting(int LineNo)
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToUnRegister()
        {
            throw new NotImplementedException();
        }

        private void OnFailToUnRegister()
        {
            throw new NotImplementedException();
        }

        private void OnTryingToUnRegister()
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToReRegister()
        {
            throw new NotImplementedException();
        }

        private void OnFailToReRegisterEx(int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnFailToReRegister()
        {
            throw new NotImplementedException();
        }

        private void OnTryingToReRegister()
        {
            throw new NotImplementedException();
        }

        private void OnFailToRegisterEx(int StatusCode, string ReasonPhrase)
        {
            //throw new NotImplementedException();
        }

        private void OnFailToTransfer(int LineNo, int StatusCode, string ReasonPhrase)
        {
            throw new NotImplementedException();
        }

        private void OnFailToRegister()
        {
            //throw new NotImplementedException();
        }

        private void OnTryingToRegister()
        {
            throw new NotImplementedException();
        }

        private void OnSuccessToRegister()
        {
            throw new NotImplementedException();
        }

        public bool SetLicenceKey(string sLicenceKey)
        {
            return mba_objVaxVoIP.SetLicenceKey(sLicenceKey);
        }

        public bool InitializeEx(bool bBindToListenIP, string sListenIP, int nListenPort, string sUserName, string sLogin, string sLoginPwd, string sDisplayName, string sDomainRealm, string sSIPProxy, string sSIPOutBoundProxy, bool bUseSoundDevice, int nTotalLine)
        {
            return mba_objVaxVoIP.InitializeEx(bBindToListenIP, sListenIP, nListenPort, sUserName, sLogin, sLoginPwd, sDisplayName, sDomainRealm, sSIPProxy, sSIPOutBoundProxy, bUseSoundDevice, nTotalLine);
        }

        public bool RegisterToProxy(int nExpire)
        {
            return mba_objVaxVoIP.RegisterToProxy(nExpire);
        }

        public bool OpenLine(int nLineNo, bool bBindToRTPRxIP, string sRTPRxIP, int nRTPRxPort)
        {
            return mba_objVaxVoIP.OpenLine(nLineNo, bBindToRTPRxIP, sRTPRxIP, nRTPRxPort);
        }

        public bool CloseLine(int nLineNo)
        {
            return mba_objVaxVoIP.CloseLine(nLineNo);
        }

        public int GetVaxObjectError()
        {
            return mba_objVaxVoIP.GetVaxObjectError();
        }
    }
}
