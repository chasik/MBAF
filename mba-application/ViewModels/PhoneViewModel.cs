using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using mba_application.MBAComponents.MBAMessages;
using System;
using System.Diagnostics;
using System.Media;
using System.Windows.Media;
using VAXSIPUSERAGENTCOMLib;

namespace mba_application.ViewModels
{
    public class PhoneViewModel : ViewModelBase
    {
        public PhoneViewModel()
        {
            Messenger.Default.Register<CloseProgramMessage>(this, OnCloseProgram);
        }

        [Command]
        public void PhoneButtonClick(string param)
        {
            Number += param;
        }
        [Command]
        public void PhoneCallButtonClick()
        {
            if (!MBAPhone.DialCall(1, Number, -1, -1))
                Trace.WriteLine("ERROR DialCall method. CODE: " + MBAPhone.GetVaxObjectError().ToString());
            else
            {
                //MediaPlayer.Open(new Uri(@"pack://application:,,,/mba-application;component/Resources/wav/ring.wav"));
                //MediaPlayer.Play();
            }
        }
        [Command]
        public void InitializeMBAPhone()
        {
            MediaPlayer = new MediaPlayer();
            MBAPhone = new VaxVoIPSIP();

            MBAPhone.SetLicenceKey("VAXVOIP.COM-219I154I179I10I184I170I120I239I130I80I157I51I140I153I41I175I5I245I56I56I44I125I37I15I102I133I114I96I216I239I27I157I63I215I195I128I16I109I37I82I64I127I218I163I226I29I249I104I12I150I58I82I72I19I221I136I125I235I205I131I150I64I241I246I195I249I73I199I230I57I68I186I244I245I58I222I172I27I85I162I244I85I47I125I16I30I189I252I1I118I185I164I181I225I111I196I140I147I156I42I132I56I229I140I117I165I150I197I156I129I4I93I70I67I136I152I81I16I47I17I142I15I78I106I240I48I86I36I9I132I35I71I192I252I114I147I172I70I79I177I29I244I34I110I106I170I92I63I239I39I59I5I149I186I143I112I247I13I205I16I187I202I186I94I61I140I4I255I230I210I54I228I176I57I4I201I252I54I22I30I0I12I104I67I205I222I104I227I36I174I139I226I214I237I179I123I100I112I98I141I215I133I42I45I28I39I146I7I88I158I156I209I154I147I38I195I88I192I155I184I49I152I219I44I157I212I234I35I106I240I181I212I123I254I174I92I242I252I86I196I128I187I65I84I249I111I224I59I244I51I119I125I61I35I73I244I246I167I191I187I97I255I79I210I115I126I98I178I189I239I51I142I96I41I133I184I53I150I17I167I16I151I168I73I205I119I36I154I104I250I69I211I61I124I157I89I5I98I252I56I27I105I189I104I16I234I202I99I147I228I148I204I56I40I91I83I129I190I216I246I152I80I75I249I211I84I104I249I150I113I58I182I62I64I232I206I2I105I249I74I67I110I97I127I17I9I40I230I62I26I246I202I14I10I88I120I220I31I64I229I42I49I177I56I-UNLIMITED.MBAFIN.RU");

            if (!MBAPhone.InitializeEx(false, "", -1, "151", "151", "heslox151", "Chasik", "aster.mbaru.ru", "10.100.0.5", "", false, 5))
                Trace.WriteLine("ERROR InitializeEx method. CODE: " + MBAPhone.GetVaxObjectError().ToString());

            if (!MBAPhone.OpenLine(1, false, "", -1))
                Trace.WriteLine("ERROR OpenLine method. CODE: " + MBAPhone.GetVaxObjectError().ToString());

            if (!MBAPhone.RegisterToProxy(1800))
                Trace.WriteLine("ERROR RegisterToProxy method. CODE: " + MBAPhone.GetVaxObjectError().ToString());
        }
        void OnCloseProgram(CloseProgramMessage message)
        {
            MBAPhone.UnInitialize();
        }

        private VaxVoIPSIP MBAPhone;
        private MediaPlayer MediaPlayer;

        #region Properties
        public string Number
        {
            get { return GetProperty(() => Number); }
            set { SetProperty(() => Number, value); }
        }
        public PhoneState PhoneState
        {
            get { return GetProperty(() => PhoneState); }
            set { SetProperty(() => PhoneState, value); }
        }
        #endregion
    }

    public enum PhoneState
    {
        Free = 1

    }
}