using Stateless;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.Origins.WorkFlows
{
    public class CcicCusInfoStateMachine
    {
        private enum Trigger
        {

        }
        private StateMachine<CcicCusInfoStatus, Trigger> _stateMachine;
        private CcicCusInfo _ccicCusInfo;
        public CcicCusInfoStateMachine(CcicCusInfo ccicCusInfo)
        {
            _ccicCusInfo = ccicCusInfo;
            _stateMachine = new StateMachine<CcicCusInfoStatus, Trigger>(() => ccicCusInfo.Status, ccicCusInfo.SetStatus);
        }
    }
}
