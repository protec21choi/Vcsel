using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace FrameOfSystem3
{
    class MathFormula
    {
        public static double x  = 0;
        public static double b  = 0;

        public static double degreeToRadian(double angle)
        {
            double rad = 0.0;
            rad = angle * (Math.PI / 180.0);

            return rad;
        }

        public static double radianToDegree(double rad)
        {
            double angle = 0.0;
            angle = rad * 180.0 / Math.PI;

            return angle;
        }

  
        /// <summary>
        /// 2022.05.26 by jhlee [ADD] 4Point Center
        /// pt1 = LT, pt2 = RB, pt3 = RT, pt4 = LB
        /// </summary>
        /// 출처 https://wjs7347.tistory.com/17
        public static DPointXY center4Point(DPointXY pt1, DPointXY pt2, DPointXY pt3, DPointXY pt4)
        {
            DPointXY dCenter;
            

            dCenter.x = (((pt1.x * pt2.y - pt1.y * pt2.x) * (pt3.x - pt4.x)) - ((pt1.x - pt2.x) * (pt3.x * pt4.y - pt3.y * pt4.x)))
                        / ((pt1.x - pt2.x) * (pt3.y - pt4.y) - (pt1.y - pt2.y) * (pt3.x - pt4.x));

            dCenter.y = (((pt1.x * pt2.y - pt1.y * pt2.x) * (pt3.y - pt4.y)) - ((pt1.y - pt2.y) * (pt3.x * pt4.y - pt3.y * pt4.x)))
                        / ((pt1.x - pt2.x) * (pt3.y - pt4.y) - (pt1.y - pt2.y) * (pt3.x - pt4.x));

            return dCenter;
        }

        public static DPointXYT centerPtoP(DPointXYT pt1, DPointXYT pt2)
        {
            DPointXYT dCenter;

            dCenter.x = (pt1.x + pt2.x) / 2.0;
            dCenter.y = (pt1.y + pt2.y) / 2.0;
            dCenter.t = 0;

            //             dCenter.x = Math.Round(dCenter.x, 3);
            //             dCenter.y = Math.Round(dCenter.y, 3);

            return dCenter;
        }
        
		public static double centerPtoP(double v1, double v2)
		{
			return (v1 + v2) / 2;
		}
        public static DPointXY centerPtoP(DPointXY pt1, DPointXY pt2)
        {
            DPointXY dCenter;

            dCenter.x = (pt1.x + pt2.x) / 2.0;
            dCenter.y = (pt1.y + pt2.y) / 2.0;

            dCenter.x = Math.Round(dCenter.x, 3);
            dCenter.y = Math.Round(dCenter.y, 3);

            return dCenter;
        }
        public static DPointXY distancePtoP(DPointXY pt1, DPointXY pt2, bool bAbsolute = true)
        {
            DPointXY dDistance;

			// 2021.06.11 by junho [MOD] MathFormula 개선
			//dDistance = pt1 - pt2;
			dDistance = pt2 - pt1;

            if (bAbsolute)
            {
                dDistance.x = Math.Abs(dDistance.x);
                dDistance.y = Math.Abs(dDistance.y);
            }

            dDistance.x = Math.Round(dDistance.x, 3);
            dDistance.y = Math.Round(dDistance.y, 3);

            return dDistance;
        }
		public static DPointXY distanceQuantifyPtoP(DPointXY pt1, DPointXY pt2)
		{
			DPointXY result;

			result.x = Math.Abs(Math.Max(pt1.x, pt2.x) - Math.Min(pt1.x, pt2.x));
			result.y = Math.Abs(Math.Max(pt1.y, pt2.y) - Math.Min(pt1.y, pt2.y));

			return result;
		}

        // 2021.06.15. by shkim. [확인완료]
        public static double distanceDiagonalPtoP(DPointXY pt1, DPointXY pt2)
        {
            double dDistance;

            dDistance = Math.Sqrt(Math.Pow((pt2.x - pt1.x), 2) + Math.Pow((pt2.y - pt1.y), 2));

            return dDistance;
        }

		// 2022.05.15. by wdw. [MOD] 반전 좌표계 추가
        // 2021.06.15. by shkim. [확인완료]
        // 2021.06.03. by shkim. [MOD] Atan -> Atan2 (Atan 예외발생)
        // Atan2 앵글 계산의 경우 무조건 Point 2에서 Point 1을 빼줘야 한다. (Point1에서 Point2 방향의 상대 각도)
        // 두 점의 앵글을 수평선 기준으로 구할 때는 pt1의 X 좌표 값이 무조건 왼쪽에 있어야한다.
        public static double anglePtoP(DPointXY pt1, DPointXY pt2, bool bReverse_x = false, bool bReverse_y = false)
        {
            double dAngle;

            if(bReverse_x)
            {
                pt1.x *= -1;
                pt2.x *= -1;
            }
            if (bReverse_y)
            {
                pt1.y *= -1;
                pt2.y *= -1;
            }

            //  Atan2 앵글 계산의 경우 무조건 Point 2에서 Point 1을 빼줘야 한다. (Point1에서 Point2 방향의 상대 각도)
            DPointXY dOffset = pt2 - pt1;

            dAngle = Math.Atan2(dOffset.y, dOffset.x);
            dAngle = radianToDegree(dAngle);
            return dAngle;
        }
        /// <summary>        
		// 2022.05.15. by wdw. [MOD] 반전 좌표계 추가
        /// // 2021.06.15. by shkim. [확인완료]
        /// 회전변환 계산
        /// </summary>
        /// <param name="angle">적용시킬 Theta</param>
        /// <param name="ct">Center</param>
        /// <param name="pt1">Target</param>
        /// <returns></returns>
        public static DPointXY rotate(double angle, DPointXY ct, DPointXY pt1, bool bReverse_x = false, bool bReverse_y = false)
        {
            DPointXY pt2;

            double rad = degreeToRadian(angle);

            if (bReverse_x && bReverse_y)
            {
                pt2.x = ct.x - ((ct.x - pt1.x) * Math.Cos(rad) - (ct.y - pt1.y) * Math.Sin(rad));
                pt2.y = ct.y - ((ct.x - pt1.x) * Math.Sin(rad) + (ct.y - pt1.y) * Math.Cos(rad));

            }
            else if (bReverse_x)
            {
                pt2.x = ct.x - ((ct.x - pt1.x) * Math.Cos(rad) - (pt1.y - ct.y) * Math.Sin(rad));
                pt2.y = ct.y + ((ct.x - pt1.x) * Math.Sin(rad) + (pt1.y - ct.y) * Math.Cos(rad));

            }
            else if (bReverse_y)
            {
                pt2.x = ct.x + ((pt1.x - ct.x) * Math.Cos(rad) - (ct.y - pt1.y) * Math.Sin(rad));
                pt2.y = ct.y - ((pt1.x - ct.x) * Math.Sin(rad) + (ct.y - pt1.y) * Math.Cos(rad));

            }
            else
            {
                pt2.x = ct.x + ((pt1.x - ct.x) * Math.Cos(rad) - (pt1.y - ct.y) * Math.Sin(rad));
                pt2.y = ct.y + ((pt1.x - ct.x) * Math.Sin(rad) + (pt1.y - ct.y) * Math.Cos(rad));
            }
          
            pt2.x = Math.Round(pt2.x, 3);
            pt2.y = Math.Round(pt2.y, 3);

            return pt2;
        }

        // 2022.03.30 by jhchoo [ADD] 위치 회전 변환 : dPoint > dTransPoint
        public static DPointXY RotationalTransform(double dAngle, DPointXY dCenter, DPointXY dPoint)
        {
            DPointXY dTransPoint;

            double dRadian = degreeToRadian(dAngle);
            DPointXY dOffset = dPoint - dCenter;

            dTransPoint.x = dCenter.x + ((dOffset.x * Math.Cos(dRadian)) - (dOffset.y * Math.Sin(dRadian)));
            dTransPoint.y = dCenter.y + ((dOffset.x * Math.Sin(dRadian)) + (dOffset.y * Math.Cos(dRadian)));

            return dTransPoint;
        }

        public static DPointXY rotateDistance(double angle, DPointXY pt1, DPointXY pt2)
        {
            DPointXY modifyPt2 = new DPointXY(0.0, 0.0);
            DPointXY dDistance = new DPointXY(0.0, 0.0);

            double rad = degreeToRadian(angle);

            modifyPt2.x = pt1.x + (pt2.x - pt1.x) * Math.Cos(rad) - (pt2.y - pt1.y) * Math.Sin(rad);
            modifyPt2.y = pt1.y + (pt2.x - pt1.x) * Math.Sin(rad) + (pt2.y - pt1.y) * Math.Cos(rad);

            dDistance.x = Math.Abs(pt1.x - modifyPt2.x);
            dDistance.y = Math.Abs(pt1.y - modifyPt2.y);

            dDistance.x = Math.Round(dDistance.x, 3);
            dDistance.y = Math.Round(dDistance.y, 3);

            return dDistance;
        }

        public static void rotateCenter(double angle, DPointXY pt1, DPointXY pt2, out DPointXY pt_center)
        {
            double rad = degreeToRadian(angle);
            pt_center = new DPointXY();
            pt_center.x = 1 / (1 - 2 * Math.Cos(rad) + Math.Pow(Math.Cos(rad), 2) + Math.Pow(Math.Sin(rad), 2)) * (pt1.x * Math.Pow(Math.Sin(rad), 2) - pt2.y * Math.Sin(rad) - pt1.x * Math.Cos(rad) + pt1.y * Math.Sin(rad) + pt2.x + pt1.x * Math.Pow(Math.Cos(rad), 2) - Math.Cos(rad) * pt2.x);
            pt_center.y = -(pt1.x * Math.Sin(rad) - pt2.y + Math.Cos(rad) * pt2.y + pt1.y * Math.Cos(rad) - pt1.y * Math.Pow(Math.Cos(rad), 2) - pt1.y * Math.Pow(Math.Sin(rad), 2) - pt2.x * Math.Sin(rad)) /
                (1 - 2 * Math.Cos(rad) + Math.Pow(Math.Cos(rad), 2) + Math.Pow(Math.Sin(rad), 2));
        }
        public static void rotateCenter2(double angle, int side, DPointXY pt1, DPointXY pt2, out DPointXY pt_center)
        {
            double dA = 0.0;
            double dB = 0.0;
            double dC = 0.0;

            double angle1 = 0.0;
            double angle2 = 0.0;
            double angle3 = 0.0;

            double resultX = 0.0;
            double resultY = 0.0;

            // 1. 두 점 사이의 거리를 구한다.
            dB = distanceDiagonalPtoP(pt1, pt2);

            // 2. 제2코사인 법칙을 이용해 회전 중심과 회전한 점 사이의 거리를 구한다.
            dA = Math.Sqrt((dB * dB) / (2 - 2 * (Math.Cos(angle * (Math.PI / 180)))));

            // 3. 이동된 y축 거리를 구한다.
            dC = Math.Abs(pt1.y - pt2.y);

            // 4. 이등변 삼각형의 밑각 (회전 중심과 2개의 점으로 만들어진 이등변 삼각형)
            angle2 = (180 - angle) / 2;

            //---------------------------------------------------------------------//
            // dC 와 이등변 삼각형 밑면 사이의 각
            // 역 코사인 Acos(X) = Atn(-X / Sqr(-X * X + 1)) + 2 * Atn(1)
            //### angle1 = ((Math.Atan(-(dC / dB) / Math.Sqrt(-(dC / dB) * (dC / dB) + 1))) * (180 / Math.PI)) + 2 * (Math.Atan(1) * (180 / Math.PI));

            // cos 역함수 사용 (바로 상단의 atan 이용한 값과 동일)
            angle1 = radianToDegree(Math.Acos(dC / dB));

            //---------------------------------------------------------------------//

            angle3 = (180 - angle1 - angle2);

            // 회전 중심과 회전한 좌표간의 X거리
            resultX = dA * Math.Sin(angle3 * (Math.PI / 180));

            // 회전 중심과 회전한 좌표간의 Y거리
            resultY = dA * Math.Cos(angle3 * (Math.PI / 180));

            DPointXY result1 = new DPointXY(0, 0);
            DPointXY result2 = new DPointXY(0, 0);
            DPointXY ct = new DPointXY(0, 0);
            double dTempAngle1, dTempAngle2, dTempAngle3;
            double dTempAngleResult1, dTempAngleResult2;

            switch (side)
            {
                case 1:
                    // 1사분면
                    result1.x = pt1.x - resultX;
                    result1.y = pt1.y + resultY;
                    result2.x = pt2.x - resultX;
                    result2.y = pt2.y + resultY;
                    break;
                case 2:
                    // 2사분면
                    result1.x = pt1.x + resultX;
                    result1.y = pt1.y + resultY;
                    result2.x = pt2.x + resultX;
                    result2.y = pt2.y + resultY;
                    break;
                case 3:
                    // 3사분면
                    result1.x = pt1.x + resultX;
                    result1.y = pt1.y - resultY;
                    result2.x = pt2.x + resultX;
                    result2.y = pt2.y - resultY;
                    break;
                case 4:
                    // 4사분면
                    result1.x = pt1.x - resultX;
                    result1.y = pt1.y - resultY;
                    result2.x = pt2.x - resultX;
                    result2.y = pt2.y - resultY;
                    break;
            }

            ct.x = (pt1.x + pt2.x) / 2;
            ct.y = (pt1.y + pt2.y) / 2;

            dTempAngle1 = anglePtoP(pt1, pt2);
            dTempAngle2 = anglePtoP(ct, result1);
            dTempAngle3 = anglePtoP(ct, result2);


            // 요아래부터 확인필요..
            if (dTempAngle1 > 180)
                dTempAngle1 = dTempAngle1 - 180;

            if (dTempAngle2 > 180)
                dTempAngle2 = dTempAngle2 - 180;

            if (dTempAngle3 > 180)
                dTempAngle3 = dTempAngle3 - 180;

            dTempAngleResult1 = dTempAngle1 - dTempAngle2 - 90;
            if (dTempAngleResult1 < 0)
                dTempAngleResult1 *= -1;

            dTempAngleResult2 = dTempAngle1 - dTempAngle3 - 90;
            if (dTempAngleResult2 < 0)
                dTempAngleResult2 *= -1;

            if (dTempAngleResult1 <= dTempAngleResult2)
            {
                pt_center = new DPointXY(result1);
            }
            else
            {
                pt_center = new DPointXY(result2);
            }
        }
        /// <summary>
        /// Align 결과 XYT와 회전중심, 타겟위치를 받아 회전보상 및 XY 옵셋 적용 결과위치를 반환.
        /// </summary>
        public static DPointXY GetRotatePosition(DPointXYT dpAlignResult, DPointXY dpCenter, DPointXY dpTarget)
        {
            DPointXY dpRotate;
            DPointXY dpResult;
            double dAngle = dpAlignResult.t;

            // 회전보상
            dpRotate = MathFormula.rotate(dAngle, dpCenter, dpTarget);

            // XY 보상
            dpResult.x = Math.Round(dpRotate.x + dpAlignResult.x, 3);
            dpResult.y = Math.Round(dpRotate.y + dpAlignResult.y, 3);

            return dpResult;
        }

        /// <summary>
        /// 2020.06.24 by junho [ADD]
        /// 두 Double의 중앙값을 반환한다.
        /// 내부에서 High Low 구분함
        /// </summary>
        public static double GetMedianDtoD(double dValue1, double dValue2, bool bABS = false)
        {
            double dHigh, dLow, dResult;
            if(dValue1 == dValue2) return dValue1;
            if(dValue1 > dValue2)
            {
                dHigh = dValue1;
                dLow = dValue2;
            }
            else
            {
                dHigh = dValue2;
                dLow = dValue1;
            }

            if (dHigh >= 0 && dLow >= 0)
            {
                dResult = (dHigh - dLow) / 2;
            }
            else if (dHigh >= 0 && dLow < 0)
            {
                dResult = (dHigh + dLow) / 2;
            }
            else if (dHigh <= 0 && dLow < 0)
            {
                dResult = (dLow - dHigh) / 2;
            }
            else
            {
                // Console.WriteLine("[junho] MathFormula.GetCenterDtoD 확인");
                dResult = 0.0;
            }

            if (bABS) dResult = Math.Abs(dResult);

            return dResult;
        }
		/// <summary>
		/// 두 점의 1차 방정식 기울기 반환
		/// </summary>
		public static double segmentGradient(DPointXY pt1, DPointXY pt2)
		{
			return (pt1.y - pt2.y) / (pt1.x - pt2.x);
		}
		/// <summary>
		/// 두 점의 1차 방정식 y절편 반환
		/// </summary>
		public static double segmentIntersept(DPointXY pt1, DPointXY pt2)
		{
			return (-1 * pt1.x) * ((pt1.y - pt2.y) / (pt1.x - pt2.x)) + pt1.y;
		}
		/// <summary>
		/// 두 직선의 교차점을 반환한다.
		/// isSegment : 선분으로 범위를 제한
		/// </summary>
		public static bool crossPointByTwiceLine(DPointXY pointA1, DPointXY pointA2, DPointXY pointB1, DPointXY pointB2, out DPointXY result, bool isSegment = false)
		{
			double t;
			double s;
			double under = (pointB2.y - pointB1.y) * (pointA2.x - pointA1.x) - (pointB2.x - pointB1.x) * (pointA2.y - pointA1.y);
			if (under == 0) { result = new DPointXY(); return false; }		// 교차점x (평행 관계)

			double _t = (pointB2.x - pointB1.x) * (pointA1.y - pointB1.y) - (pointB2.y - pointB1.y) * (pointA1.x - pointB1.x);
			double _s = (pointA2.x - pointA1.x) * (pointA1.y - pointB1.y) - (pointA2.y - pointA1.y) * (pointA1.x - pointB1.x);
			if (_t == 0 && _s == 0) { result = new DPointXY(); return false; }

			t = _t / under;
			s = _s / under;

			if (isSegment)	// 선분일 경우 범위를 제한
			{
				if (t < 0.0 || t > 1.0 || s < 0.0 || s > 1.0) { result = new DPointXY(); return false; }
			}


			result.x = pointA1.x + (t * (pointA2.x - pointA1.x));
			result.y = pointA1.y + (t * (pointA2.y - pointA1.y));

			return true;
		}
    }
}
