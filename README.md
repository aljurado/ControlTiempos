# Control de Tiempos
![Captura1](https://user-images.githubusercontent.com/99470557/161240664-e02fe251-6fca-4f8a-bd4c-1a90a36e55bf.PNG)

Esta pequeña aplicación la uso para controlar los tiempos empleados en las diferentes tareas. Es una herramienta últil si tienes que controlar el tiempo empleado, por ejemplo, con tus diferentes clientes si facturas por horas, o simplemente si quieres saber el tiempo empleado en cada tarea.

## Funcionamiento
Es muy simple.

Por un lado hay 2 campos obligatorios, el de *Cliente* y el de *Tarea*. Si además le pones una referencia (*Ref.*), este campo es opcional, puedes filtrar mejor si tienes varios trabajos de un mismo cliente.

Una vez le das al botón de *INICIAR* se pone en marcha el contador de tiempo.

![Captura2](https://user-images.githubusercontent.com/99470557/161240727-418bea87-ec63-49c3-aa28-16e375b4a953.PNG)

Durante el periodo de control de tiempo puedes pausar la captura tantas veces como consideres oportuno. El tiempo de pausa se acumulará y se restará del tiempo de captura.

Para finalizar pulsa sobre el botón *PARAR* y se detiene el proceso, y guarda los datos (los tiempos de pausa no los guarda) en un archivo de tipo *csv* para que sea facilmente consultable por cualquier programa de hoja de cálculo.

![Captura4](https://user-images.githubusercontent.com/99470557/161240937-b853cf65-4998-413e-8ba2-bb9f72baa40e.PNG)

Para facilitar el trabajo con clientes o referencias repetitivas el programa permite que puedas seleccionar uno ya guardado o agregar uno para usarlo posteriormente. Simplemente escribe en el cuadro de texto de *Cliente* o *Ref.* lo que quieras y pulsa el botón *+*.

En caso que el cliente o raferencía ya existan te avisa.

## Configuración
Pulsando sobre el botón configurar se despliegan algunas opciones que permiten personalizar algunos comportamientos de la aplicación.

![Captura3](https://user-images.githubusercontent.com/99470557/161240768-863f7cc2-6c48-4671-9e41-29825a49a78b.PNG)

Con la opcion de *Siempre visible*, activa por defecto, mantienes la ventana siempre activa por encima del resto y puedes ir viendo en contador.

Con la opción *Mostrar tiempo en pausa*, inactiva por defecto, puedes ver el tiempo en pausa que llevas.

Con la opción *Mostrar segundos*, el reloj muestra también los segundos.

Con la opción *Guardar posición en la pantalla*, la aplicación inicia en la posicion donde se ha guardado la configuración. Con esta opción desactivada se inicia en el centro de la pantalla.

Permite especificar un nombre de archivo para guardar el historial de control.

