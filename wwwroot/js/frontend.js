function mascaraCPF(input) {
    // Remove tudo que não for número
    let value = input.value.replace(/\D/g, '');
    
    // Adiciona pontos e traço na máscara de CPF
    if (value.length > 9) {
        value = value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
    } else if (value.length > 6) {
        value = value.replace(/(\d{3})(\d{3})(\d{3})/, "$1.$2.$3");
    } else if (value.length > 3) {
        value = value.replace(/(\d{3})(\d{3})/, "$1.$2");
    }
    
    input.value = value;
}

function mascaraCelular(input) {
    let value = input.value.replace(/\D/g, '');  // Remove tudo que não for número

    if (value.length > 10) {
        // Formato com DDD + 9 dígitos: (XX) XXXXX-XXXX
        input.value = value.replace(/(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
    } else if (value.length > 5) {
        // Formato com DDD + 8 dígitos: (XX) XXXX-XXXX
        input.value = value.replace(/(\d{2})(\d{4})(\d{4})/, '($1) $2-$3');
    } else if (value.length > 2) {
        // Formato com apenas o DDD: (XX)
        input.value = value.replace(/(\d{2})(\d{0,5})/, '($1) $2');
    } else {
        input.value = value;
    }
}
