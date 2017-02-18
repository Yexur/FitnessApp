using System.Collections.Generic;

namespace FitnessApp.Models.ApplicationViewModels
{
    public class FitnessClassSignUpList
    {
        private List<FitnessClassSignUpView> _fitnessClassSignUpViewList;
        public List<FitnessClassSignUpView> FitnessClassSignUpView {
            get
            {
                return _fitnessClassSignUpViewList ?? new List<FitnessClassSignUpView>();
            }
        }

        public FitnessClassSignUpList()
        {
        }

        public FitnessClassSignUpList(List<FitnessClassSignUpView> fitnessClassSignUpViewList)
        {
            _fitnessClassSignUpViewList = fitnessClassSignUpViewList;
        }
    }
}
