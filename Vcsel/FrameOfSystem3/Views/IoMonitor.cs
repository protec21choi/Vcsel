﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

using Define.DefineEnumProject.DigitalIO;
using Define.DefineEnumProject.AnalogIO;

using DigitalIO_;
using AnalogIO_;
using Sys3Controls;

namespace FrameOfSystem3.Views
{
	public class IoMonitor
	{
		#region filed
		Sys3Label _myLabel = null;
		Sys3LedLabelWithText _myLedLabel = null;

		bool _useDi = false;
		bool _useDo = false;
		bool _useAi = false;

		EN_DIGITAL_IN[] _targetDi;	// background (or logic)
		EN_DIGITAL_OUT[] _targetDo;	// active (and logic)
		EN_ANALOG_IN _targetAi;		// sub text

		DigitalIO _digitalIo = null;
		AnalogIO _analogIo = null;
		#endregion /filed

		#region constructor
		public IoMonitor(Sys3Label label, EN_DIGITAL_IN dIn)
		{
			_myLabel = label;

			_useDi = true;
			_targetDi = new EN_DIGITAL_IN[] { dIn };
			_digitalIo = DigitalIO.GetInstance();
		}
		public IoMonitor(Sys3LedLabelWithText ledLabel, EN_DIGITAL_OUT dOut)
		{
			_myLedLabel = ledLabel;

			_useDo = true;
			_targetDo = new EN_DIGITAL_OUT[] { dOut };

			_digitalIo = DigitalIO.GetInstance();
		}
		public IoMonitor(Sys3Label label, EN_ANALOG_IN aIn)
		{
			_myLabel = label;

			_useAi = true;
			_targetAi = aIn;

			_analogIo = AnalogIO.GetInstance();
		}

		public IoMonitor(Sys3LedLabelWithText ledLabel, EN_DIGITAL_OUT dOut, EN_DIGITAL_IN dIn)
		{
			_myLedLabel = ledLabel;

			_useDi = true;
			_targetDi = new EN_DIGITAL_IN[] { dIn };

			_useDo = true;
			_targetDo = new EN_DIGITAL_OUT[] { dOut };

			_digitalIo = DigitalIO.GetInstance();
		}
		public IoMonitor(Sys3Label label, EN_DIGITAL_IN dIn, EN_ANALOG_IN aIn)
		{
			_myLabel = label;

			_useDi = true;
			_targetDi = new EN_DIGITAL_IN[] { dIn };

			_useAi = true;
			_targetAi = aIn;

			_digitalIo = DigitalIO.GetInstance();
			_analogIo = AnalogIO.GetInstance();
		}
		public IoMonitor(Sys3LedLabelWithText ledLabel, EN_DIGITAL_OUT dOut, EN_ANALOG_IN aIn)
		{
			_myLedLabel = ledLabel;

			_useDo = true;
			_targetDo = new EN_DIGITAL_OUT[] { dOut };

			_useAi = true;
			_targetAi = aIn;

			_digitalIo = DigitalIO.GetInstance();
			_analogIo = AnalogIO.GetInstance();
		}

		public IoMonitor(Sys3Label label, EN_DIGITAL_IN[] dIn)
		{
			_myLabel = label;

			_useDi = true;
			_targetDi = dIn;

			_digitalIo = DigitalIO.GetInstance();
		}
		public IoMonitor(Sys3LedLabelWithText ledLabel, EN_DIGITAL_OUT[] dOut)
		{
			_myLedLabel = ledLabel;

			_useDo = true;
			_targetDo = dOut;

			_digitalIo = DigitalIO.GetInstance();
		}
		// 필요하면 더 만들기
		#endregion /constructor

		public void Refresh()
		{
			if(_useDi)
			{
				bool isDiOn = false;
				foreach(EN_DIGITAL_IN dIn in _targetDi)
				{
					if (_digitalIo.ReadInput((int)dIn))
					{
						isDiOn = true;
						break;
					}
				}

				Color color = isDiOn ? Color.HotPink : Color.White;
				if (_myLabel != null)			_myLabel.BackGroundColor = color;
				else if (_myLedLabel != null)	_myLedLabel.BackGroundColor = color;
			}
			if(_useDo)
			{
				bool isDoOn = false;
				foreach (EN_DIGITAL_OUT dOut in _targetDo)
				{
					if (_digitalIo.ReadOutput((int)dOut))
					{
						isDoOn = true;
						break;
					}
				}

				if (_myLedLabel != null) _myLedLabel.Active = isDoOn;
			}
			if(_useAi)
			{
				string readAi = Math.Round(_analogIo.ReadInputValue((int)_targetAi), 1).ToString("0.0");
				if (_myLabel != null)			_myLabel.SubText = readAi;
				else if (_myLedLabel != null)	_myLedLabel.SubText = readAi;
			}
		}
		public void Click_Event()
		{
			if (false == _useDo) return;

			bool isDoOn = false;
			foreach (EN_DIGITAL_OUT dOut in _targetDo)
			{
				if (_digitalIo.ReadOutput((int)dOut))
				{
					isDoOn = true;
					break;
				}
			}
			foreach (EN_DIGITAL_OUT dOut in _targetDo)
			{
				_digitalIo.WriteOutput((int)dOut, false == isDoOn);
			}
		}
	}
}
