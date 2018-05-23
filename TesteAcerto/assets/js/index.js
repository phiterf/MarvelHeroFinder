/// <reference path="../../scripts/axios.js" />
/// <reference path="../../scripts/vue.js" />


Vue.prototype.$http = axios;
Vue.component('paginate', VuejsPaginate)

var app = new Vue({
    el: '#app',
    data: {
        termo: '',
        carregando: false,
        personagem: null,
        naoEncontrado: false,
        historias: null,
        totalHistorias : 0,
        carregandoHistorias: false,
        por_pagina : 20
    },
    methods: {
        busca: function() {
            if (!this.termo.trim()) return;
            var $vm = this;
            $vm.personagem = null;
            $vm.historias = null;
            $vm.carregandoHistorias = false;
            $vm.totalHistorias = 0;
            $vm.naoEncontrado = false;
            $vm.carregando = true;
            $vm.$http.get('/api/Busca/' + encodeURIComponent(this.termo)).then(function (response) {
                var personagem = response.data;
                if (!personagem) {
                    $vm.naoEncontrado = true;
                    return;
                }
                $vm.personagem = personagem;
            })
            .catch(function () {
                console.log('Erro no servidor.');
            })
            .then(function () {
                $vm.carregando = false;
            })
        },
        verHistorias: function (pagina) {
            var $vm = this;
            $vm.carregandoHistorias = true;
            $vm.$http.get('/api/Historias/' + $vm.personagem.Id + '-' + pagina).then(function (response) {
                $vm.historias = response.data.historias;
                $vm.totalHistorias = response.data.total;
            })
            .catch(function () {
                console.log('Erro no servidor.');
            })
            .then(function () {
                $vm.carregandoHistorias = false;
            })
        }
    },
    computed: {
        pageCount: function () {
            return Math.floor(this.totalHistorias/ this.por_pagina);
        }
    }
});