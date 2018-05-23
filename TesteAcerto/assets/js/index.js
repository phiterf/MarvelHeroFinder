/// <reference path="../../scripts/axios.js" />
/// <reference path="../../scripts/vue.js" />


Vue.prototype.$http = axios;

var app = new Vue({
    el: '#app',
    data: {
        termo: '',
        carregando: false,
        personagem: null
    },
    methods: {
        busca: function() {
            if (!this.termo.trim()) return;
            var $vm = this;
            $vm.personagem = null;
            $vm.carregando = true;
            $vm.$http.get('/api/Busca/' + encodeURIComponent(this.termo)).then(function (response) {
                var personagem = response.data;
                if (!personagem) {
                    alert('Não encontramos um personagem com este nome!');
                    return;
                }

                $vm.personagem = personagem;
                $vm.carregando = false;
            })
        }
    }
});