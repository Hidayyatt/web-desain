using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("api/[controller]/[action]")]

public class DataSiswaController : ControllerBase
{
    public class DataUser
    {
        public string? userid { get; set; }
        public string? namauser { get; set; }
        public string? pass { get; set; }
    }
    public class APIResult
    {
        public string? code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public string? data { get; set; }
    }

    public class DataPayload
    {
        public string? userid { get; set; }
        public string? pass { get; set; }
    }


    public List<DataPayload> lstpayload = new List<DataPayload>();
    public List<APIResult> lstapiresult = new List<APIResult>();
    public List<DataUser> lstdatauser = new List<DataUser>();

    [HttpPost]
    public IActionResult Login([FromForm] string payload)
    {
        Console.WriteLine(payload);
        lstpayload.Add(JsonSerializer.Deserialize<DataPayload>(payload));
        foreach (var item in lstpayload)
        {
            if (item.userid == "001" && item.pass == "123")
            {
                lstapiresult.Add(new APIResult { code = "200", status = "Success", message = "Loggeg In", data = "Andi" });
                return Ok(lstapiresult);
            }
            else
            {
                lstapiresult.Add(new APIResult { code = "401", status = "Unauthorized", message = "Failed", data = "Null" });
                return Ok(lstapiresult);
            }
        }

        return BadRequest();
    }

    [HttpPost]
    public IActionResult Users([FromForm] string payload)
    {
        lstpayload.Add(JsonSerializer.Deserialize<DataPayload>(payload));
        lstdatauser.Add(new DataUser { userid = "01", namauser = "Andi", pass = "123" });
        lstdatauser.Add(new DataUser { userid = "02", namauser = "Budi", pass = "456" });
        string res = null;
        foreach (var item in lstdatauser)
            if (item.userid == lstpayload[0].userid && item.pass == lstpayload[0].pass)
            {
                res = item.namauser;
                Console.WriteLine("Berhasil");
                break;
            }

        return Ok(lstdatauser);
    }

    [HttpPost]
    public IActionResult Quiz([FromForm] string payload)
    {
        // Validasi payload
        if (string.IsNullOrWhiteSpace(payload))
        {
            return BadRequest(new APIResult
            {
                code = "400",
                status = "Bad Request",
                message = "Payload tidak boleh kosong",
                data = null
            });
        }

        try
        {
            // Deserialize JSON payload
            var dataPayload = JsonSerializer.Deserialize<DataPayload>(payload);

            if (dataPayload == null)
            {
                return BadRequest(new APIResult
                {
                    code = "400",
                    status = "Bad Request",
                    message = "Payload tidak valid",
                    data = null
                });
            }

            // Data user
            var users = new List<DataUser>
        {
            new DataUser
            {
                userid = "001",
                namauser = "Andi",
                pass = "123"
            },
            new DataUser
            {
                userid = "002",
                namauser = "Arif",
                pass = "111"
            }
        };

            // Cari user berdasarkan userid dan password
            var user = users.FirstOrDefault(x =>
                x.userid == dataPayload.userid &&
                x.pass == dataPayload.pass);

            // User ditemukan
            if (user != null)
            {
                Console.WriteLine("Berhasil");

                return Ok(new APIResult
                {
                    code = "200",
                    status = "Success",
                    message = "Logged In",
                    data = user.namauser
                });
            }

            // User tidak ditemukan
            return Unauthorized(new APIResult
            {
                code = "401",
                status = "Unauthorized",
                message = "Failed",
                data = null
            });
        }
        catch (JsonException)
        {
            return BadRequest(new APIResult
            {
                code = "400",
                status = "Bad Request",
                message = "Format JSON payload tidak valid",
                data = null
            });
        }
    }
}