using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 어셈블리의 일반 정보는 다음 특성 집합을 통해 제어됩니다.
// 어셈블리와 관련된 정보를 수정하려면
// 이 특성 값을 변경하십시오.
[assembly: AssemblyTitle("FrameOfSystem3")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("FrameOfSystem3")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible을 false로 설정하면 이 어셈블리의 형식이 COM 구성 요소에 
// 표시되지 않습니다.  COM에서 이 어셈블리의 형식에 액세스하려면 
// 해당 형식에 대해 ComVisible 특성을 true로 설정하십시오.
[assembly: ComVisible(false)]

// 이 프로젝트가 COM에 노출되는 경우 다음 GUID는 typelib의 ID를 나타냅니다.
[assembly: Guid("d25530cf-6aca-46cf-8f66-73ce5adc0921")]

// 어셈블리의 버전 정보는 다음 네 가지 값으로 구성됩니다.
//
//      주 버전
//      부 버전 
//      빌드 번호
//      수정 버전
//
// 모든 값을 지정하거나 아래와 같이 '*'를 사용하여 빌드 번호 및 수정 버전이 자동으로
// 지정되도록 할 수 있습니다.
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.8.9.7")]

#region <VERSION HISTORY>

#region <1.0.0.0>
/// 1. Program Release
/// 
/// 
#endregion

#region <1.1.1.0>
/// 23.12.05
/// 1. pyrometer 제거
/// 2. equipment trasfer contact pos 추가
/// 3. laser 옵션 off 시 head flow 감시 안하게 변경
#endregion

#region <1.2.1.1>
/// 23.12.07
/// 1. WORK TOOL 추가(EMITTER, GLASS)
/// 2. Transfer Entry 개선
/// 3. chller Alarm 추가
/// 4. FFU 통신 개선
/// 5. Interlock Interfarance Message 개선
/// 6. Equipement Load 전 회피동작 추가
#endregion

#region <1.3.2.1>
/// 23.12.13
/// 1. COMMUNICATION UI 추가
/// 2. TRANSFER UI 개선
/// 3. TOOL UI 추가
/// 4. LASER COOLING TIME 추가
#endregion

#region <1.3.3.1>
/// 23.12.18
/// 1. ON/OFF UI 변경
#endregion

#region <1.4.3.2>
/// 23.12.21
/// 1. SMEMA / WCF ALARM 추가
/// 2. WCF 통신 SEQUENCE 개선
/// 3. PRE HEAATING 추가
/// 4. IR RECIPE CONTROL 추가
#endregion

#region <1.4.4.2>
/// 24.03.08
/// 1. POWERMETER 개조 변경
/// 2. ALARM CONFIG MESSAGE 표시 변경
#endregion

#region <1.5.4.3>
/// 24.06.21
/// 1. EFEM 통신추가
/// 2. RECIPE 저장 버튼 추가
/// 3. 장비시작시 LASER PARAMETER 확인 추가
/// 4. WAFER INFOR UI 추가
#endregion

#region <1.5.5.4>
/// 24.06.21
/// 1. BLOCK VAC ON SEQ 변경
/// 2. WCF 통신 BUG FIX
#endregion

#region <1.6.6.5>
/// 24.06.21
/// 1. Handler Loading 전 자재 확인 추가(VAC 사용)
/// 2. 외각 POWER OFFSET 추가
/// 3. Recipe - Heater 연동 개선
/// 4. Warpage Pusher 동작 Vac OK 시 Skip 하도록 변경
/// 5. PreHeating Reset Time 변경 (Loading 중 Vac OK 시 초기화)
/// 6. Powermeter Handler 회피추가.
/// 7. Power Cal 변경 Log 추가.
/// 
#endregion

#region <1.7.7.5>
/// 24.08.27
/// 1. RAM Metrics 추가
/// 2. POWERMETER HOME SEQ 순서 변경
/// 
#endregion

#region <1.8.8.6>
/// 24.08.27
/// 1. RAM Metrics Export 기능 추가
/// 2. SIDE POWER OFFSET 기능 변경(중심 출력 안 변하도록) 
/// 3. gridview Toggle 개선
/// 4. 1channel power측정 위치 변경(1channel 사용시에만 사용 channel로 이동)
#endregion

#region <1.8.9.7>
/// 24.11.07
/// 1. RAM Metrics 정리 변경
/// 2. POWER 측정 LASER 출력 시간 개선
#endregion

#region <sample>
///
/// 
///
#endregion

#endregion </VERSION HISTORY>