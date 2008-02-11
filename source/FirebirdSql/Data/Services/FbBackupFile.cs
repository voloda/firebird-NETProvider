﻿/*
 *	Firebird ADO.NET Data provider for .NET and Mono 
 * 
 *	   The contents of this file are subject to the Initial 
 *	   Developer's Public License Version 1.0 (the "License"); 
 *	   you may not use this file except in compliance with the 
 *	   License. You may obtain a copy of the License at 
 *	   http://www.firebirdsql.org/index.php?op=doc&id=idpl
 *
 *	   Software distributed under the License is distributed on 
 *	   an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either 
 *	   express or implied. See the License for the specific 
 *	   language governing rights and limitations under the License.
 * 
 *	Copyright (c) 2002, 2007 Carlos Guzman Alvarez
 *	All Rights Reserved.
 */

using System;

namespace FirebirdSql.Data.Services
{
    public class FbBackupFile
    {
        #region · Fields ·

        private string backupFile;
        private int backupLength;

        #endregion

        #region · Properties ·

        public string BackupFile
        {
            get { return this.backupFile; }
            set { this.backupFile = value; }
        }

        public int BackupLength
        {
            get { return this.backupLength; }
            set { this.backupLength = value; }
        }

        #endregion

        #region · Constructors ·

        public FbBackupFile(string fileName, int fileLength)
        {
            this.backupFile = fileName;
            this.backupLength = fileLength;
        }

        #endregion
    }
}
