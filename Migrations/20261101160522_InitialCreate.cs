using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftIQ.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    geofence_radius_meters = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.branch_id);
                    table.ForeignKey(
                        name: "FK_Branch_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    reward_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    points_required = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.reward_id);
                    table.ForeignKey(
                        name: "FK_Reward_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    shift_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    grace_period_minutes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.shift_id);
                    table.ForeignKey(
                        name: "FK_Shift_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_User_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_User_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.department_id);
                    table.ForeignKey(
                        name: "FK_Department_Branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "Branch",
                        principalColumn: "branch_id");
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    audit_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    entity_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    entity_id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.audit_log_id);
                    table.ForeignKey(
                        name: "FK_AuditLog_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_read = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_Notification_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    employee_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    job_title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hired_on = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "department_id");
                    table.ForeignKey(
                        name: "FK_Employee_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "AIInsight",
                columns: table => new
                {
                    insight_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confidence_score = table.Column<decimal>(type: "decimal(5,4)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIInsight", x => x.insight_id);
                    table.ForeignKey(
                        name: "FK_AIInsight_Company_company_id",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_AIInsight_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    leave_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reviewed_by = table.Column<int>(type: "int", nullable: true),
                    reviewed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    decision_note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.leave_request_id);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "PointTransaction",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    transaction_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTransaction", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_PointTransaction_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "RewardRequest",
                columns: table => new
                {
                    reward_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    reward_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    requested_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRequest", x => x.reward_request_id);
                    table.ForeignKey(
                        name: "FK_RewardRequest_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_RewardRequest_Reward_reward_id",
                        column: x => x.reward_id,
                        principalTable: "Reward",
                        principalColumn: "reward_id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftAssignment",
                columns: table => new
                {
                    assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    shift_id = table.Column<int>(type: "int", nullable: false),
                    effective_from = table.Column<DateTime>(type: "date", nullable: false),
                    effective_to = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignment", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_ShiftAssignment_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_ShiftAssignment_Shift_shift_id",
                        column: x => x.shift_id,
                        principalTable: "Shift",
                        principalColumn: "shift_id");
                });

            migrationBuilder.CreateTable(
                name: "TrustedDevice",
                columns: table => new
                {
                    device_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    device_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    device_identifier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    is_trusted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_used_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustedDevice", x => x.device_id);
                    table.ForeignKey(
                        name: "FK_TrustedDevice_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    attendance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shift_assignment_id = table.Column<int>(type: "int", nullable: false),
                    check_in_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    check_out_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    check_in_latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    check_in_longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gps_accuracy_m = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    verification_status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.attendance_id);
                    table.ForeignKey(
                        name: "FK_Attendance_ShiftAssignment_shift_assignment_id",
                        column: x => x.shift_assignment_id,
                        principalTable: "ShiftAssignment",
                        principalColumn: "assignment_id");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceCorrection",
                columns: table => new
                {
                    correction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    attendance_id = table.Column<int>(type: "int", nullable: false),
                    requested_check_in = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requested_check_out = table.Column<DateTime>(type: "datetime2", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reviewed_by = table.Column<int>(type: "int", nullable: true),
                    reviewed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    decision_note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceCorrection", x => x.correction_id);
                    table.ForeignKey(
                        name: "FK_AttendanceCorrection_Attendance_attendance_id",
                        column: x => x.attendance_id,
                        principalTable: "Attendance",
                        principalColumn: "attendance_id");
                    table.ForeignKey(
                        name: "FK_AttendanceCorrection_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AIInsight_company_id",
                table: "AIInsight",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_AIInsight_employee_id",
                table: "AIInsight",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_shift_assignment_id",
                table: "Attendance",
                column: "shift_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCorrection_attendance_id",
                table: "AttendanceCorrection",
                column: "attendance_id");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceCorrection_employee_id",
                table: "AttendanceCorrection",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_user_id",
                table: "AuditLog",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_company_id",
                table: "Branch",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_branch_id",
                table: "Department",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_department_id",
                table: "Employee",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_user_id",
                table: "Employee",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_employee_id",
                table: "LeaveRequest",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_user_id",
                table: "Notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PointTransaction_employee_id",
                table: "PointTransaction",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_company_id",
                table: "Reward",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRequest_employee_id",
                table: "RewardRequest",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRequest_reward_id",
                table: "RewardRequest",
                column: "reward_id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_name",
                table: "Role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shift_company_id",
                table: "Shift",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignment_employee_id",
                table: "ShiftAssignment",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignment_shift_id",
                table: "ShiftAssignment",
                column: "shift_id");

            migrationBuilder.CreateIndex(
                name: "IX_TrustedDevice_employee_id",
                table: "TrustedDevice",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_company_id",
                table: "User",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIInsight");

            migrationBuilder.DropTable(
                name: "AttendanceCorrection");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PointTransaction");

            migrationBuilder.DropTable(
                name: "RewardRequest");

            migrationBuilder.DropTable(
                name: "TrustedDevice");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "ShiftAssignment");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
