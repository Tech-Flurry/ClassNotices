using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Telephony.Gsm;
using System;
using ClassNotices.Model;
using ClassNotices.DataHandler;
using System.Threading;

namespace ClassNotices
{
    [Activity(Label = "ClassNotices", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        JAVAdb java = new JAVAdb();
        OSdb os = new OSdb();
        ERPdb erp = new ERPdb();
        Compilerdb compiler = new Compilerdb();
        Numericaldb num = new Numericaldb();
        SEdb se = new SEdb();
        Button btnOS, btnNum, btnSE, btnJAVA, btnComp, btnERP;
        EditText txtmsg;
        TextView count, status;
        Thread t;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            java.CreateDatabase();
            os.CreateDatabase();
            erp.CreateDatabase();
            compiler.CreateDatabase();
            num.CreateDatabase();
            se.CreateDatabase();
            btnJAVA = FindViewById<Button>(Resource.Id.btnJAVA);
            try
            {
                btnJAVA.Text = "JAVA (" + java.selectTablePerson().Count + ")";
            }
            catch (NullReferenceException)
            {
                btnJAVA.Text = "JAVA (0)";
            }
            btnOS = FindViewById<Button>(Resource.Id.btnOS);
            try
            {
                btnOS.Text = "OS (" + os.selectTablePerson().Count + ")";
            }
            catch (NullReferenceException)
            {
                btnOS.Text = "OS (0)";
            }
            btnERP = FindViewById<Button>(Resource.Id.btnERP);
            try
            {
                btnERP.Text = "ERP (" + erp.selectTablePerson().Count + ")";
            }
            catch (NullReferenceException)
            {
                btnERP.Text = "ERP (0)";
            }
            btnComp = FindViewById<Button>(Resource.Id.btnComp);
            try
            {
                btnComp.Text = "Compiler (" + compiler.selectTablePerson().Count + ")";
            }
            catch (NullReferenceException)
            {
                btnComp.Text = "Compiler (0)";
            }
            btnNum = FindViewById<Button>(Resource.Id.btnNum);
            try
            {
                btnNum.Text = "Numerical (" + num.selectTable().Count + ")";
            }
            catch (NullReferenceException)
            {
                btnNum.Text = "Numerical (0)";
            }
            btnSE = FindViewById<Button>(Resource.Id.btnSE);
            try
            {
                btnSE.Text = "SE (" + se.selectTablePerson().Count + ")";
            }
            catch (NullReferenceException)
            {
                btnSE.Text = "SE (0)";
            }
            txtmsg = FindViewById<EditText>(Resource.Id.messageBox);
            count = FindViewById<TextView>(Resource.Id.wordCount);
            status = FindViewById<TextView>(Resource.Id.txtStatus);
            btnSE.Click += BtnSE_Click;
            btnNum.Click += BtnNum_Click;
            btnComp.Click += BtnComp_Click;
            btnERP.Click += BtnERP_Click;
            btnOS.Click += BtnOS_Click;
            btnJAVA.Click += BtnJAVA_Click;
            txtmsg.TextChanged += Txtmsg_TextChanged;
        }
        protected override void OnDestroy()
        {
            if (t == null || t.ThreadState == ThreadState.Stopped)
            {
                t.Abort();
            }
            base.OnDestroy();
        }
        private void Txtmsg_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            int length = 160;
            length = length - txtmsg.Length();
            count.Text = length.ToString();
        }

        private void BtnJAVA_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Length != 0)
            {
                if (t == null || t.ThreadState != ThreadState.Running)
                {
                    if (t != null)
                    {
                        t.Abort();
                    }
                    t = new Thread(BtnJavaClick);
                    t.Start();
                }
                else
                {
                    
                    Toast.MakeText(this, "Wait until previous SMS are being Sending", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Cannot send an empty SMS.", ToastLength.Short).Show();
            }
        }
        void BtnJavaClick()
        {
            try
            {
                JAVAdb db = new JAVAdb();
                db.CreateDatabase();
                int dbCount = db.selectTablePerson().Count;
                int i = 0;
                foreach (Contact c in db.selectTablePerson())
                {
                    SmsManager.Default.SendTextMessage(c.Number, null, txtmsg.Text, null, null);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Info(ex.GetType().ToString(), ex.Message);
            }
        }

        private void BtnOS_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Length != 0)
            {
                if (t == null || t.ThreadState != ThreadState.Running)
                {
                    if (t != null)
                    {
                        t.Abort();
                    }
                    t = new Thread(BtnOSClick);
                    t.Start();
                }
                else
                {
                    Toast.MakeText(this, "Wait until previous SMS are being Sending", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Cannot send an empty SMS.", ToastLength.Short).Show();
            }
        }
        void BtnOSClick()
        {
            try
            {
                OSdb db = new OSdb();
                db.CreateDatabase();
                int dbCount = db.selectTablePerson().Count;
                int i = 0;
                foreach (Contact c in db.selectTablePerson())
                {
                    SmsManager.Default.SendTextMessage(c.Number, null, txtmsg.Text, null, null);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Info(ex.GetType().ToString(), ex.Message);
            }
        }
        private void BtnERP_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Length != 0)
            {
                if (t == null || t.ThreadState != ThreadState.Running)
                {
                    if (t != null)
                    {
                        t.Abort();
                    }
                    t = new Thread(BtnERPClick);
                    t.Start();
                }
                else
                {
                    Toast.MakeText(this, "Wait until previous SMS are being Sending", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Cannot send an empty SMS.", ToastLength.Short).Show();
            }
        }
        void BtnERPClick()
        {
            try
            {
                ERPdb db = new ERPdb();
                db.CreateDatabase();
                int dbCount = db.selectTablePerson().Count;
                int i = 0;
                foreach (Contact c in db.selectTablePerson())
                {
                    SmsManager.Default.SendTextMessage(c.Number, null, txtmsg.Text, null, null);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Info(ex.GetType().ToString(), ex.Message);
            }
        }
        private void BtnComp_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Length != 0)
            {
                if (t == null || t.ThreadState != ThreadState.Running)
                {
                    if (t != null)
                    {
                        t.Abort();
                    }
                    t = new Thread(BtnCompClick);
                    t.Start();
                }
                else
                {
                    Toast.MakeText(this, "Wait until previous SMS are being Sending", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Cannot send an empty SMS.", ToastLength.Short).Show();
            }
        }
        void BtnCompClick()
        {
            try
            {
                Compilerdb db = new Compilerdb();
                db.CreateDatabase();
                int dbCount = db.selectTablePerson().Count;
                int i = 0;
                foreach (Contact c in db.selectTablePerson())
                {
                    SmsManager.Default.SendTextMessage(c.Number, null, txtmsg.Text, null, null);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Info(ex.GetType().ToString(), ex.Message);
            }
        }
        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Length != 0)
            {
                if (t == null || t.ThreadState != ThreadState.Running)
                {
                    if (t != null)
                    {
                        t.Abort();
                    }
                    t = new Thread(BtnNumClick);
                    t.Start();
                }
                else
                {
                    Toast.MakeText(this, "Wait until previous SMS are being Sending", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Cannot send an empty SMS.", ToastLength.Short).Show();
            }
        }
        void BtnNumClick()
        {
            try
            {
                Numericaldb db = new Numericaldb();
                db.CreateDatabase();
                int dbCount = db.selectTable().Count;
                int i = 0;
                foreach (Contact c in db.selectTable())
                {
                    SmsManager.Default.SendTextMessage(c.Number, null, txtmsg.Text, null, null);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Info(ex.GetType().ToString(), ex.Message);
            }
        }
        private void BtnSE_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Length != 0)
            {
                if (t == null || t.ThreadState != ThreadState.Running)
                {
                    if (t != null)
                    {
                        t.Abort();
                    }
                    t = new Thread(BtnSEClick);
                    t.Start();
                }
                else
                {
                    Toast.MakeText(this, "Wait until previous SMS are being Sending", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Cannot send an empty SMS.", ToastLength.Short).Show();
            }
        }
        void BtnSEClick()
        {
            try
            {
                SEdb db = new SEdb();
                db.CreateDatabase();
                int dbCount = db.selectTablePerson().Count;
                int i = 0;
                foreach (Contact c in db.selectTablePerson())
                {
                    SmsManager.Default.SendTextMessage(c.Number, null, txtmsg.Text, null, null);
                }
            }
            catch (Exception ex)
            {
                Android.Util.Log.Info(ex.GetType().ToString(), ex.Message);
            }
        }
    }
    [BroadcastReceiver]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SmsReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            //Toast.MakeText(context, SW.ToString(), ToastLength.Long).Show();
            try
            {
                if (intent.HasExtra("pdus"))
                {
                    var smsArray = (Java.Lang.Object[])intent.Extras.Get("pdus");
                    foreach (var item in smsArray)
                    {
                        var sms = SmsMessage.CreateFromPdu((byte[])item);
                        string address = sms.OriginatingAddress;
                        string message = sms.MessageBody;
                        extra e = new extra(address, message);
                    }
                }
            }
            catch (Exception e)
            {
                Toast.MakeText(context, e.Message.ToString(), ToastLength.Long);
            }
        }
    }
    public class extra : MainActivity
    {
        public extra(string add, string message)
        {
            try
            {
                if (message.ToUpper().Contains("#NUMERICAL"))
                {
                    Contact contact = new Contact(add);
                    Numericaldb db = new Numericaldb();
                    db.CreateDatabase();
                    db.Insert(contact);
                    SmsManager.Default.SendTextMessage(add, null, "Your request for Numerical Computing subject's notifications is recieved", null, null);
                }
                if (message.ToUpper().Contains("#JAVA"))
                {
                    Contact contact = new Contact(add);
                    JAVAdb db = new JAVAdb();
                    db.CreateDatabase();
                    db.InsertIntoTablePerson(contact);
                    SmsManager.Default.SendTextMessage(add, null, "Your request for JAVA subject's notifications is recieved", null, null);
                }
                if (message.ToUpper().Contains("#COMPILER"))
                {
                    Contact contact = new Contact(add);
                    Compilerdb db = new Compilerdb();
                    db.CreateDatabase();
                    db.InsertIntoTablePerson(contact);
                    SmsManager.Default.SendTextMessage(add, null, "Your request for Compiler Construction subject's notifications is recieved", null, null);
                }
                if (message.ToUpper().Contains("#SE"))
                {
                    Contact contact = new Contact(add);
                    SEdb db = new SEdb();
                    db.CreateDatabase();
                    db.InsertIntoTablePerson(contact);
                    SmsManager.Default.SendTextMessage(add, null, "Your request for Software Engineering subject's notifications is recieved", null, null);
                }
                if (message.ToUpper().Contains("#ERP"))
                {
                    Contact contact = new Contact(add);
                    ERPdb db = new ERPdb();
                    db.CreateDatabase();
                    db.InsertIntoTablePerson(contact);
                    SmsManager.Default.SendTextMessage(add, null, "Your request for Enterprize Resource Planning subject's notifications is recieved", null, null);
                }
                if (message.ToUpper().Contains("#OS"))
                {
                    Contact contact = new Contact(add);
                    OSdb db = new OSdb();
                    db.CreateDatabase();
                    db.InsertIntoTablePerson(contact);
                    SmsManager.Default.SendTextMessage(add, null, "Your request for Operating System subject's notifications is recieved", null, null);
                }
            }
            catch (Exception e)
            {
                Android.Util.Log.Info(e.InnerException.GetType().ToString(), e.Message);
            }
        }
    }
}

