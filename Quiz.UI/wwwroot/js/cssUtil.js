// Seleciona todos os elementos com a classe contendo "color-[...]"
document.querySelectorAll('[class*="color-["]').forEach(element => {
    // Extrai a cor do nome da classe (regex entre colchetes [])
    const colorMatch = element.className.match(/color-\[(.*?)]/);

    if (colorMatch) {
         // Pega a cor dentro dos colchetes
        element.style.color = colorMatch[1]; // Aplica a cor no estilo inline
    }
});