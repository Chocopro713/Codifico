document.getElementById('updateData').addEventListener('click', function() {
    // Obtener los datos del input
    const input = document.getElementById('sourceData').value;
    const data = input.split(',').map(d => +d.trim()).filter(d => !isNaN(d));

    // Limpiar el área del gráfico
    const chart = d3.select('#chart');
    chart.selectAll('*').remove();

    if (data.length === 0) return;

    // Configuraciones del gráfico
    const width = 600;  // Aumenta el ancho del gráfico para barras más largas
    const height = 300;
    const barHeight = height / data.length;
    const maxDataValue = d3.max(data);
    const padding = 30; // Espacio adicional para las etiquetas de los ejes
    const colorScale = d3.scaleOrdinal(d3.schemeCategory10);

    // Crear el SVG
    const svg = chart.append('svg')
        .attr('width', width)
        .attr('height', height);

    // Crear la escala para el ancho de las barras
    const xScale = d3.scaleLinear()
        .domain([0, maxDataValue])
        .range([0, width - padding]);

    // Crear las barras
    svg.selectAll('rect')
        .data(data)
        .enter()
        .append('rect')
        .attr('x', padding)
        .attr('y', (d, i) => i * barHeight + 5) // Añadir un pequeño margen
        .attr('width', d => xScale(d))
        .attr('height', barHeight - 10) // Añadir un pequeño margen
        .attr('fill', (d, i) => colorScale(i % 10))
        .attr('class', 'bar');

    // Agregar etiquetas dentro de las barras
    svg.selectAll('text')
        .data(data)
        .enter()
        .append('text')
        .attr('x', d => xScale(d) + padding - 10) // Asegura que el texto esté dentro de la barra
        .attr('y', (d, i) => i * barHeight + (barHeight / 2) + 5) // Centra el texto verticalmente
        .attr('text-anchor', 'end')
        .text(d => d)
        .attr('fill', 'black')
        .attr('font-size', '12px');
});
