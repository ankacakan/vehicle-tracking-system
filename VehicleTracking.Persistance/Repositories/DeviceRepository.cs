using Dapper;
using VehicleTracking.Application.Features.DeviceCommand.Queries;
using VehicleTracking.Application.Features.DeviceFeatures.Queries;
using VehicleTracking.Application.Features.ReportFeatures.Queries;
using VehicleTracking.Application.IRepositories;
using VehicleTracking.Domain.Dtos;
using VehicleTracking.Domain.Entities;
using VehicleTracking.Persistence.Data;

namespace VehicleTracking.Persistence.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly DapperContext _context;

    public DeviceRepository(DapperContext context) => _context = context;
    public async Task<IEnumerable<Device>> GetAsync(GetDeviceQuery getDevice, CancellationToken cancellationToken)
    {
        using var conn = _context.CreateConnection();
        const string sql = @"SELECT  ILKSINYALTARIH
	,CIHAZTIPI
	,CIHAZID
	,IMEINO
	,CASE 
		WHEN DATEDIFF(hour, KONTROLTARIH, GETDATE()) < 1
			THEN 1
		ELSE 0
		END AS ONLINE
	,CONCAT (
		RIGHT(SERVERIP, 3)
		,' '
		,CONNTYPE
		,' '
		,(
			CASE 
				WHEN SERVERIP LIKE '10.%'
					THEN '-APN'
				ELSE CASE 
						WHEN IPNO <> '1.1.1.1'
							AND IPNO NOT LIKE '10.%'
							THEN '-INTERNET'
						ELSE ''
						END
				END
			)
		) AS SERVERIP
	,LASTSTOP
	,SKTARIH
	,(
		CASE 
			WHEN abs(datediff(minute, KONTROLTARIH, getdate())) > 10
				THEN 'Veri Yok'
			ELSE CASE 
					WHEN CURRENTSPEED < 5
						THEN CASE 
								WHEN KONTAK = '1'
									THEN 'Rolanti'
								ELSE 'Park'
								END
					ELSE 'Hareketli'
					END
			END
		) AS DURUM
FROM clients c WITH (NOLOCK) INNER JOIN userclients as u on u.CLIENTID=c.ID
INNER JOIN firmalar as f on f.ID=u.USERID
WHERE f.FIRMAKODU=@customerCode";
        return await conn.QueryAsync<Device>(sql, new { getDevice.customerCode });
    }

  
}
