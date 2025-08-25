namespace UNICAMP.MedicalSimulator
{

    public interface MedicalRuntimeElement
    {
        public void OnEnter();
        public void OnExecute();
        public void OnExit();
    }
}