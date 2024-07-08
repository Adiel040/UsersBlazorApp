using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UsersBlazorApp.Data.Models;

public partial class AspNetUsers
{
    [Key]
    public int UserId { get; set; }

    [StringLength(256)]
    public string? UserName { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; } = new List<AspNetUserClaims>();

    [ForeignKey("UserId")]
    [InverseProperty("User")]
    public virtual ICollection<AspNetRoles> Role { get; set; } = new List<AspNetRoles>();

    [ForeignKey("UserId")]
    public ICollection<AspNetRoleClaims> UserDetalle {  get; set; } = new List<AspNetRoleClaims>();
}
