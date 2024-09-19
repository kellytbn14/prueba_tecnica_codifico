document.addEventListener("DOMContentLoaded", function () {
    const width = 600;
    const height = 700;
    const margin = { top: 20, right: 20, bottom: 30, left: 40 }; //los márgenes para espaciar el gráfico dentro del SVG

    const svg = createSvg(width, height, margin);

    const xScale = d3.scaleLinear(); //Escala lineal para el eje X (ancho de las barras).
    const yScale = d3.scaleBand().padding(0.1); //scala de banda para el eje Y (posicionamiento vertical de las barras), con un relleno del 10%.

    const color = d3.scaleOrdinal(d3.schemeCategory10);

    document.getElementById("updateData").addEventListener("click", () => {
        const input = document.getElementById("sourceData").value;
        //const input = "22,55,63,48,14,58"
        const numericData = validateAndProcessInput(input);

        if (!numericData) return;

        updateScales(numericData, xScale, yScale, width, height, margin);
        renderBars(svg, numericData, xScale, yScale, color);
        renderLabels(svg, numericData, xScale, yScale);

        //Dibujar eje X
        /*svg.append("g")
            .attr("class", "x-axis")
            .attr("transform", `translate(0,${height - margin.top - margin.bottom})`)
            .call(d3.axisBottom(xScale));
        
        //Dibujar eje Y
        svg.append("g")
            .attr("class", "y-axis")
            .call(d3.axisLeft(yScale).tickFormat((d, i) => `Bar ${i + 1}`));*/
    });

    function createSvg(width, height, margin) {
        const svg = d3.select("#chart") //Selecciona el elemento con ID chart
            .append("svg")
            .attr("width", width)
            .attr("height", height)
            .append("g") //Crea un grupo dentro del SVG para contener los elementos del gráfico
            .attr("transform", `translate(${margin.left},${margin.top})`); //Desplaza el grupo dentro del SVG según los márgenes para que el contenido no esté pegado al borde.
        return svg
    }

    function updateScales(data, xScale, yScale, width, height, margin) {
        xScale.domain([0, d3.max(data)]) //Establece que el rango de datos va de 0 al máximo valor en data
            .range([0, width - margin.left - margin.right]); //Establece que el rango en el SVG va desde 0 hasta el ancho disponible

        yScale.domain(data.map((_, i) => i)) //Usa los índices de los datos para definir el dominio.
            .range([0, height - margin.top - margin.bottom]); //Establece el rango en el SVG para la altura disponible
    }

    function renderBars(svg, data, xScale, yScale, color) {
        svg.selectAll("*").remove(); // Limpiar SVG antes de renderizar

        svg.selectAll(".bar") //Selecciona todas las barras existentes.
            .data(data) //Asocia los datos a las barras.
            .enter() //Identifica nuevos datos que no tienen un elemento gráfico correspondiente.
            .append("rect") //Añade un nuevo rectángulo (barra) por cada dato.
            .attr("class", "bar") //asigna la clase bar a cada rectángulo.
            .attr("x", 0) //Posiciona cada barra en el inicio del eje x.
            .attr("y", (d, i) => yScale(i)) //Posiciona cada barra en el eje y según su índice.
            .attr("width", d => xScale(d)) //Establece el ancho de cada barra según su valor.
            .attr("height", yScale.bandwidth()) //Establece la altura de cada barra según el espacio disponible en la escala y
            .attr("fill", (d, i) => color(i));
    }

    function renderLabels(svg, data, xScale, yScale) {
        // Agregar etiquetas de texto al final de cada barra
        svg.selectAll(".label")
            .data(data)
            .enter()
            .append("text")
            .attr("class", "label")
            .attr("x", d => xScale(d) - 30) // Posicionar al final de la barra
            .attr("y", (d, i) => yScale(i) + yScale.bandwidth() / 2) // Centrar verticalmente
            .attr("dy", ".35em") // Ajustar verticalmente para centrar el texto
            .attr("fill", "white")
            .attr("font-weight", "bold")
            .text(d => d);
    }

    function validateAndProcessInput(input) {
        const data = input.split(",").map(d => d.trim()).filter(d => d !== "");
        const allValid = data.every(d => /^-?\d+$/.test(d));

        if (!allValid) {
            alert("Por favor, ingrese solo números enteros válidos (sin letras ni caracteres especiales).");
            return null;
        }

        const numericData = data.map(d => +d);
        if (numericData.length === 0) {
            alert("Por favor, ingrese algunos datos válidos.");
            return null;
        }

        return numericData;
    }
});
