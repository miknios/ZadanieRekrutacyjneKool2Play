using Cinemachine;

namespace Installers
{
	public class CinemachineDataProvider
	{
		public CinemachineFixedSignal DefaultCinemachineFixedSignal { get; }
		
		public CinemachineDataProvider(CinemachineFixedSignal defaultCinemachineFixedSignal)
		{
			DefaultCinemachineFixedSignal = defaultCinemachineFixedSignal;
		}
	}
}