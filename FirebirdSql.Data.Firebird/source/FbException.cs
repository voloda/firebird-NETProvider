/*
 *  Firebird ADO.NET Data provider for .NET and Mono 
 * 
 *     The contents of this file are subject to the Initial 
 *     Developer's Public License Version 1.0 (the "License"); 
 *     you may not use this file except in compliance with the 
 *     License. You may obtain a copy of the License at 
 *     http://www.ibphoenix.com/main.nfs?a=ibphoenix&l=;PAGES;NAME='ibp_idpl'
 *
 *     Software distributed under the License is distributed on 
 *     an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either 
 *     express or implied.  See the License for the specific 
 *     language governing rights and limitations under the License.
 * 
 *  Copyright (c) 2002, 2004 Carlos Guzman Alvarez
 *  All Rights Reserved.
 */

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using FirebirdSql.Data.Firebird.Gds;

namespace FirebirdSql.Data.Firebird
{
	/// <include file='Doc/en_EN/FbException.xml' path='doc/class[@name="FbException"]/overview/*'/>
	[Serializable]
	public sealed class FbException : SystemException
	{
		#region Fields
		
		private FbErrorCollection	errors = new FbErrorCollection();
		private int					errorCode;
		
		#endregion

		#region Properties

		/// <include file='Doc/en_EN/FbException.xml' path='doc/class[@name="FbException"]/property[@name="Errors"]/*'/>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public FbErrorCollection Errors
		{
			get { return this.errors; }
		}

		/// <include file='Doc/en_EN/FbException.xml' path='doc/class[@name="FbException"]/property[@name="ErrorCode"]/*'/>
		public int ErrorCode
		{
			get { return this.errorCode; }
		}

		#endregion

		#region Constructors

		internal FbException() : base()
		{
		}

		internal FbException(string message) : base(message)
		{
		}

		internal FbException(
			SerializationInfo	info, 
			StreamingContext	context) : base(info, context)
		{
			this.errors		= (FbErrorCollection)info.GetValue("errors", typeof(FbErrorCollection));
			this.errorCode	= info.GetInt32("errorCode");
		}

		internal FbException(
			string			message, 
			GdsException	ex) : base(message)
		{
			this.errorCode	= ex.ErrorCode;
			this.Source		= ex.Source;

			this.GetIscExceptionErrors(ex);
		}

		#endregion

		#region Methods

		public override void GetObjectData(
			SerializationInfo info,
			StreamingContext context)
		{
			info.AddValue("errors", this.errors);
			info.AddValue("errorCode", this.errorCode);

			base.GetObjectData(info, context);
		}

		#endregion

		#region Internal Methods

		internal void GetIscExceptionErrors(GdsException ex)
		{
			foreach (GdsError error in ex.Errors)
			{
				this.errors.Add(error.Message, error.ErrorCode);
			}
		}

		#endregion
	}
}
