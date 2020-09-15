using Cinemachine;

namespace Installers
{
	public class CinemachineDataProvider
	{
		public CinemachineFixedSignal CinemachineFixedSignal { get; }
		
		public CinemachineDataProvider(CinemachineFixedSignal cinemachineFixedSignal)
		{
			CinemachineFixedSignal = cinemachineFixedSignal;
		}
	}
}