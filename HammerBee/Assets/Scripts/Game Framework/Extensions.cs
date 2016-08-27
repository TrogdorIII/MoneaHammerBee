using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

namespace ExtensionMethods
{
    public static class CSharpExtensionMethods
    {
        #region Any Type
        /// <summary>
        /// Returns true if this object is equal to any of the values in the parameters (with the same Type).
        /// </summary>
        /// <returns>Returns a Boolean</returns>
        public static bool IsIn<T>(this T source, params T[] list)
        {
            if (source == null) throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        /// <summary>
        /// Returns true if this object is null.
        /// </summary>
        /// <returns>Returns a Boolean</returns>
        public static bool IsNull<T>(this T source)
        {
            if (source == null) return true; else return false;
        }

        #region Comparators
        /// <summary>
        /// Returns true if this IComparable is between lower and upper (exclusive).
        /// </summary>
        /// <param name="lower">The lower value to compare to</param>
        /// <param name="upper">The upper value to compare to</param>
        /// <returns>Returns a Boolean</returns>
        public static bool IsBetween<T>(this T source, T lower, T upper) where T : IComparable<T>
        {
            return source.CompareTo(lower) > 0 && source.CompareTo(upper) < 0;
        }

        /// <summary>
        /// Returns true if this IComparable is between lower and upper (inclusive).
        /// </summary>
        /// <param name="lower">The lower value to compare to</param>
        /// <param name="upper">The upper value to compare to</param>
        /// <returns>Returns a Boolean</returns>
        public static bool IsBetweenInclusive<T>(this T source, T lower, T upper) where T : IComparable<T>
        {
            return source.CompareTo(lower) >= 0 && source.CompareTo(upper) <= 0;
        }

        /// <summary>
        /// Returns true if this IComparable is between lower and upper (inclusive lower).
        /// </summary>
        /// <param name="lower">The lower value to compare to (inclusive)</param>
        /// <param name="upper">The upper value to compare to</param>
        /// <returns>Returns a Boolean</returns>
        public static bool IsBetweenInclusiveLower<T>(this T source, T lower, T upper) where T : IComparable<T>
        {
            return source.CompareTo(lower) >= 0 && source.CompareTo(upper) < 0;
        }

        /// <summary>
        /// Returns true if this IComparable is between lower and upper (inclusive upper).
        /// </summary>
        /// <param name="lower">The lower value to compare to</param>
        /// <param name="upper">The upper value to compare to (inclusive)</param>
        /// <returns>Returns a Boolean</returns>
        public static bool IsBetweenInclusiveUpper<T>(this T source, T lower, T upper) where T : IComparable<T>
        {
            return source.CompareTo(lower) > 0 && source.CompareTo(upper) <= 0;
        }
        #endregion

        #endregion

        #region String
        /// <summary>
        /// Returns the number of words in a String.
        /// </summary>
        public static int WordCount(this string s)
        {
            return s.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        #endregion

        #region Int32

        #endregion

        #region IList
        /// <summary>
        /// Return a random item from the list.
        /// </summary>
        public static T RandomItem<T>(this IList<T> list)
        {
            if (list.Count == 0) throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Shuffle the list in place using the Fisher-Yates method.
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        #endregion
    }

    public static class UnityExtensionMethods
    {
        #region Vector2
        /// <summary>
        /// Returns the original Vector2 with the specified x value.
        /// </summary>
        /// <param name="x">The new x value</param>
        /// <returns>Returns a Vector2</returns>
        public static Vector2 WithX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }

        /// <summary>
        /// Returns the original Vector2 with the specified y value.
        /// </summary>
        /// <param name="y">The new y value</param>
        /// <returns>Returns a Vector2</returns>
        public static Vector2 WithY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }

        /// <summary>
        /// Returns a Vector3 with the original values of the Vector2 and the specified z value.
        /// </summary>
        /// <param name="z">The new z value</param>
        /// <returns>Returns a Vector3</returns>
        public static Vector3 WithZ(this Vector2 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
        #endregion

        #region Vector3
        /// <summary>
        /// Returns a Vector2 with the x and y values of this Vector3.
        /// </summary>
        /// <returns>Returns a Vector2</returns>
        public static Vector2 xy(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        /// <summary>
        /// Returns the original Vector3 with the specified x value.
        /// </summary>
        /// <param name="x">The new x value</param>
        /// <returns>Returns a Vector3</returns>
        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        /// <summary>
        /// Returns the original Vector3 with the specified y value.
        /// </summary>
        /// <param name="y">The new y value</param>
        /// <returns>Returns a Vector3</returns>
        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }

        /// <summary>
        /// Returns the original Vector3 with the specified z value.
        /// </summary>
        /// <param name="z">The new z value</param>
        /// <returns>Returns a Vector3</returns>
        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }
        #endregion

        #region Transform
        /// <summary>
        /// Sets the x position of the Transform to the float passed.
        /// </summary>
        /// <param name="t">The Transform to set</param>
        /// <param name="x">The new x value</param>
        public static void SetPositionX(this Transform t, float x)
        {
            t.position = new Vector3(x, t.position.y, t.position.z);
        }

        /// <summary>
        /// Sets the y position of the Transform to the float passed.
        /// </summary>
        /// <param name="t">The Transform to set</param>
        /// <param name="y">The new y value</param>
        public static void SetPositionY(this Transform t, float y)
        {
            t.position = new Vector3(t.position.x, y, t.position.z);
        }

        /// <summary>
        /// Sets the z position of the Transform to the float passed.
        /// </summary>
        /// <param name="t">The Transform to set</param>
        /// <param name="z">The new z value</param>
        public static void SetPositionZ(this Transform t, float z)
        {
            t.position = new Vector3(t.position.x, t.position.y, z);
        }

        /// <summary>
        /// Sets the position of the Transform to the float passed along the specified axis.
        /// </summary>
        /// <param name="t">The Transform to set</param>
        /// <param name="axisName">Axis to use when setting the Transform's position</param>
        /// <param name="value">The new value of the Transform's specified axis</param>
        public static void SetPositionByAxis(this Transform t, string axisName, float value)
        {
            switch (axisName)
            {
                default:
                    throw new ArgumentOutOfRangeException(axisName, "axisName must be either x, y or z");

                case "x":
                    t.position = new Vector3(value, t.position.y, t.position.z);
                    break;
                case "y":
                    t.position = new Vector3(t.position.x, value, t.position.z);
                    break;
                case "z":
                    t.position = new Vector3(t.position.x, t.position.y, value);
                    break;
            }
        }

        public static Transform[] GetChildren(this Transform root)
        {
            Transform[] list = new Transform[root.childCount];
            for (int i = 0; i < root.childCount; i++)
            {
                list[i] = root.GetChild(i);
            }
            return list;
        }

        public static List<Transform> GetChildrenList(this Transform root)
        {
            List<Transform> list = new List<Transform>();
            for (int i = 0; i < root.childCount; i++)
            {
                list[i] = root.GetChild(i);
            }
            return list;
        }
        #endregion

        #region GameObject
        /// <summary>
        /// Gets a Component attached to the given GameObject.
        /// If one isn't found, a new one is attached and returned.
        /// </summary>
        /// <returns>Previously or newly attached component</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        /// <summary>
        /// Checks whether a GameObject has a Component of type T attached.
        /// </summary>
        /// <returns>True when component is attached</returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }
        #endregion

        #region RigidBody
        /// <summary>
        /// Changes the direction of a Rigidbody without changing its speed.
        /// </summary>
        /// <param name="rigidbody">The Rigidbody to change the direction of</param>
        /// <param name="direction">The new direction of the Rigidbody</param>
        public static void ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
        {
            rigidbody.velocity = direction * rigidbody.velocity.magnitude;
        }
        #endregion

        #region Color
        /// <summary>
        /// Returns the Color with the new alpha.
        /// </summary>
        /// <param name="color">The Color that is being referenced</param>
        /// <param name="alpha">The new alpha value</param>
        /// <returns>Returns a Color</returns>
        public static Color WithAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        /// <summary>
        /// Sets the alpha of the Color.
        /// </summary>
        /// <param name="color">The Color that is being set</param>
        /// <param name="alpha">The new alpha value</param>
        public static void SetAlpha(this Color color, float alpha)
        {
            color = new Color(color.r, color.g, color.b, alpha);
        }
        #endregion

        public static float RoundBetween(this Mathf mathf, float f, float min, float max)
        {
            return (f >= min + ((max - min) / 2)) ? max : min;
        }
    }
}