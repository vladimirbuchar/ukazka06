﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables.Edu.Organization
{
    [Table("Edu_OrganizationFileRepository")]
    public class OrganizationFileRepositoryDbo : FileRepositoryModel
    {
        public OrganizationDbo Organization { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
