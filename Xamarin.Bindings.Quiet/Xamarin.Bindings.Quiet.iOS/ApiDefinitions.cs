using ObjCRuntime;
using Foundation;
using System;

namespace Xamarin.Bindings.Quiet.iOS
{
    // @interface QMTransmitterConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface QMTransmitterConfig
    {
        // -(id)initWithProfile:(NSString *)profile forKey:(NSString *)key;
        [Export("initWithProfile:forKey:")]
        IntPtr Constructor(string profile, string key);

        // -(id)initWithKey:(NSString *)key;
        [Export("initWithKey:")]
        IntPtr Constructor(string key);

        // @property unsigned int numBuffers;
        [Export("numBuffers")]
        uint NumBuffers { get; set; }

        // @property unsigned int bufferLength;
        [Export("bufferLength")]
        uint BufferLength { get; set; }
    }

    // @interface QMReceiverConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface QMReceiverConfig
    {
        // -(id)initWithProfile:(NSString *)profile forKey:(NSString *)key;
        [Export("initWithProfile:forKey:")]
        IntPtr Constructor(string profile, string key);

        // -(id)initWithKey:(NSString *)key;
        [Export("initWithKey:")]
        IntPtr Constructor(string key);

        // @property unsigned int numBuffers;
        [Export("numBuffers")]
        uint NumBuffers { get; set; }

        // @property unsigned int bufferLength;
        [Export("bufferLength")]
        uint BufferLength { get; set; }
    }

    // @interface QMFrameTransmitter : NSObject
    [BaseType(typeof(NSObject))]
    interface QMFrameTransmitter
    {
        // -(id)initWithConfig:(QMTransmitterConfig *)conf;
        [Export("initWithConfig:")]
        IntPtr Constructor(QMTransmitterConfig conf);

        // -(void)send:(NSData *)frame;
        [Export("send:")]
        void Send(NSData frame);

        // -(void)setBlocking:(long)seconds withNano:(long)nano;
        [Export("setBlocking:withNano:")]
        void SetBlocking(nint seconds, nint nano);

        // -(void)setNonBlocking;
        [Export("setNonBlocking")]
        void SetNonBlocking();

        // -(void)close;
        [Export("close")]
        void Close();
    }

    // typedef void (^QMFrameReceiverCallback)(NSData *);
    delegate void QMFrameReceiverCallback(NSData arg0);

    // @interface QMFrameReceiver : NSObject
    [BaseType(typeof(NSObject))]
    interface QMFrameReceiver
    {
        // -(id)initWithConfig:(QMReceiverConfig *)conf;
        [Export("initWithConfig:")]
        IntPtr Constructor(QMReceiverConfig conf);

        // -(NSData *)receive;
        [Export("receive")]
        NSData Receive { get; }

        // -(void)setReceiveCallback:(QMFrameReceiverCallback)newCallback;
        [Export("setReceiveCallback:")]
        void SetReceiveCallback(QMFrameReceiverCallback newCallback);

        // -(void)setBlocking:(long)seconds withNano:(long)nano;
        [Export("setBlocking:withNano:")]
        void SetBlocking(nint seconds, nint nano);

        // -(void)setNonBlocking;
        [Export("setNonBlocking")]
        void SetNonBlocking();

        // -(void)close;
        [Export("close")]
        void Close();
    }
}