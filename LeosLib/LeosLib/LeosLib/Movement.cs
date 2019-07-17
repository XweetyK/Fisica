using System;
using UnityEngine;

namespace LeosLib
{
	public static class Movement
	{
		public const float _gravedad = 9.81f;

		public static Vector3 MRU(float speed, Vector3 dir)
		{
			dir *= speed * Time.deltaTime;

			return dir;
		}

		public static float MRUV(float speed, float acceleration, float timePassed)
		{
			float _newPos = speed * Time.deltaTime + 0.5f * acceleration * Mathf.Pow(timePassed, 2.0f) * Time.deltaTime;

			return _newPos;
		}

		public static float TiroOblicuo(float speed, float timePassed)
		{
			float _newPos = speed * Time.deltaTime - 0.5f * _gravedad * Mathf.Pow(timePassed, 2.0f) * Time.deltaTime;

			return _newPos;
		}

		public static Vector3 MCU(float angle, float radio)
		{
			Vector3 _newPos = radio * Mathf.Cos(angle) * Vector3.right + radio * Mathf.Sin(angle) * Vector3.up;
			return _newPos;
		}

		public static float VelocidadAngular(float angleInit, float angleFin, float timeInit, float timeFin)
		{
			float _angle = angleInit - angleFin;
			float _time = timeInit - timeFin;
			return _angle / _time;
		}

		public static void AceleracionCircular(float radius, float acceleration, ref float initialAngularSpeed, float minSpeed, float maxSpeed)
		{
			float _currentAngularSpeed = 0f;
			_currentAngularSpeed = acceleration * Time.deltaTime + initialAngularSpeed;
			_currentAngularSpeed = Mathf.Clamp(_currentAngularSpeed, minSpeed, maxSpeed);
			initialAngularSpeed = _currentAngularSpeed;
		}
	}
}