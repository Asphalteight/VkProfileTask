# VkProfileTask

Чтобы приложение смогло подключиться к базе данных, сперва следует запустить проект для миграции базы данных. Для этого в корне приложения нужно ввести:
### dotnet run --project src/VkTask/Host/VkTask.Host.Migrator 
или же запустить его любым другим способом.

<pre>

</pre>

Затем можно запускать проект с API:
### dotnet run --project src/VkTask/Host/VkTask.Host.Api
или же другим способом.

<pre>

</pre>

После этого в браузере автоматически откроется Swagger UI, в котором можно совершать все запросы к API. 

![изображение](https://github.com/Asphalteight/VkProfileTask/assets/128236389/65f130cc-2f0b-48f3-addb-d51909d32e2c)

#### API будет расположено по адресу https://localhost:7100
