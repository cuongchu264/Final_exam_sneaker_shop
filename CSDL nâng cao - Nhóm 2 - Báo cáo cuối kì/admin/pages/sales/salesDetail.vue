<template>
    <main>
        <div class="mt-5">
            <h3 class="text-center">" DOANH THU "</h3>
        </div>
        <div class="container mt-4">
            <div class="header-body">
                <div class="row">
                    <div class="col-md-6 col-xl-12">
                        <div class="card card-stats mb-4" show-footer-line="true"><!----><!----><!---->
                        <div class="card-body"><!----><!---->
                        <div class="row">
                            <div class="col">
                                <h5 class="card-title text-uppercase text-muted mb-0">Tổng số đơn hàng
                                </h5>
                                <span class="h2 font-weight-bold mb-0">
                                    {{listBill.length}}
                                </span>
                            </div>
                            <div class="col-auto">
                                <div>
                                    <svg data-v-41be6633="" viewBox="0 0 16 16" width="2em" height="2em" focusable="false" role="img" aria-label="cart" xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi-cart mx-auto b-icon bi"><g data-v-41be6633=""><path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"></path></g></svg>
                                </div>
                            </div>
                        </div>
                        <div class="mt-3">
                            <b-form @submit.prevent="sale()">
                                <a href="/sales/flagshipChart" class="btn btn-success">Top 6 sản phẩm bán chạy</a>
                                <b-button type="submit" class="btn btn-success">Chi tiết đơn hàng theo tháng</b-button>
                            </b-form>
                        </div>
                        </div><!----><!----><!----><!---->
                        </div>
                    </div>

                    <div class="col-md-6 col-xl-12">
                        <div class="card card-stats mb-4" show-footer-line="true"><!----><!----><!---->
                        <div class="card-body"><!----><!---->
                        <div class="row">
                            <div class="col">
                                <h5 class="card-title text-uppercase text-muted mb-0">Tổng số doanh thu
                                </h5>
                                <span class="h2 font-weight-bold mb-0">
                                    {{total.toLocaleString()}}VND
                                </span>
                            </div>
                            <div class="col-auto">
                                <div>
                                    <svg data-v-41be6633="" viewBox="0 0 16 16" width="2em" height="2em" focusable="false" role="img" aria-label="pie chart" xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi-pie-chart mx-auto b-icon bi"><g data-v-41be6633=""><path d="M7.5 1.018a7 7 0 0 0-4.79 11.566L7.5 7.793V1.018zm1 0V7.5h6.482A7.001 7.001 0 0 0 8.5 1.018zM14.982 8.5H8.207l-4.79 4.79A7 7 0 0 0 14.982 8.5zM0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8z"></path></g></svg>
                                </div>
                            </div>
                        </div>
                        <div class="mt-3">
                            <b-form @submit.prevent="money()">
                                <b-button type="submit" class="btn btn-success">Chi tiết doanh thu theo tháng</b-button>
                            </b-form>
                        </div>
                        </div><!----><!----><!----><!---->
                        </div>
                    </div>

                    <div class="col-md-6 col-xl-12">
                        <div class="card card-stats mb-4" show-footer-line="true"><!----><!----><!---->
                        <div class="card-body"><!----><!---->
                        <div class="row">
                            <div class="col">
                                <h5 class="card-title text-uppercase text-muted mb-0">Tổng số khách hàng
                                </h5>
                                <span class="h2 font-weight-bold mb-0">
                                    {{listuser.length}}
                                </span>
                            </div>
                            <div class="col-auto">
                                <div>
                                    <svg data-v-41be6633="" viewBox="0 0 16 16" width="2em" height="2em" focusable="false" role="img" aria-label="person" xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi-person mx-auto b-icon bi"><g data-v-41be6633=""><path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"></path></g></svg>                                </div>
                            </div>
                        </div>
                        <div class="mt-3">
                            <b-form @submit.prevent="user()">
                                <b-button type="submit" class="btn btn-success">Chi tiết khách hàng theo tháng</b-button>
                            </b-form>
                        </div>
                        </div><!----><!----><!----><!---->
                        </div>
                    </div>
                                        <div class="col-md-6 col-xl-12">
                        <div class="card card-stats mb-4" show-footer-line="true"><!----><!----><!---->
                        <div class="card-body"><!----><!---->
                        <div class="row">
                            <div class="col">
                                <h5 class="card-title text-uppercase text-muted mb-0">Tổng số khách hàng phẩn hồi
                                </h5>
                                <span class="h2 font-weight-bold mb-0">
                                    {{loadListCustomertSP.length}}
                                </span>
                            </div>
                            <div class="col-auto">
                                <div>
                                    <svg data-v-41be6633="" viewBox="0 0 16 16" width="2em" height="2em" focusable="false" role="img" aria-label="person" xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi-person mx-auto b-icon bi"><g data-v-41be6633=""><path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z"></path></g></svg>                                </div>
                            </div>
                        </div>
                        <div class="mt-3">
                            <b-form @submit.prevent="user()">
                                <b-button type="submit" class="btn btn-success">Chi tiết khách hàng phản hồi theo tháng</b-button>
                            </b-form>
                        </div>
                        </div><!----><!----><!----><!---->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</template>
<script>
import catalogApi from '@/api/catalogApi'
export default {
    layout: 'default',
    middleware: ['isAuthorize'],
    data(){
        return{
            listBill:[],
            listuser: [],
            sumbill:[],
            listUserviaMonth:[],
            listBillviaMonthMar:[],
            listBillviaMonthApr:[],
            listBillviaMonthMay:[],
            loadListCustomertSP:[],
        }
    },

    async created(){
        await this.getBill()
        await this.getUser()
        await this.getBillviaMonthMar()
        await this.getBillviaMonthApr()
        await this.getBillviaMonthMay()
        await  this.loadListCustomert()
    },

    computed:{
        total() {
            let total = 0;
            for(let i = 0; i < this.listBill.length; i++) {
                total += this.listBill[i].total * 23000;
            }
                return total;
        },
        totalviaMonthMar() {
            let totalviaMonthMar = 0;
            for(let i = 0; i < this.listBillviaMonthMar.length; i++) {
                totalviaMonthMar += this.listBillviaMonthMar[i].total;
            }
                return totalviaMonthMar;
        },
        totalviaMonthApr() {
            let totalviaMonthApr = 0;
            for(let i = 0; i < this.listBillviaMonthApr.length; i++) {
                totalviaMonthApr += this.listBillviaMonthApr[i].total;
            }
                return totalviaMonthApr;
        },
        totalviaMonthMay() {
            let totalviaMonthMay = 0;
            for(let i = 0; i < this.listBillviaMonthMay.length; i++) {
                totalviaMonthMay += this.listBillviaMonthMay[i].total;
            }
                return totalviaMonthMay;
        },
    },

    methods:{
        async getBill(){
                try{
                const { data } = await catalogApi.getBill(this.$axios)
                console.log(data)
                this.listBill = data
                }catch(err){
                console.log(err)
                }
        },

        async getBillviaMonthMar(){
                try{
                const { data } = await catalogApi.getBillviaMonth(this.$axios,3)
                console.log(data)
                this.listBillviaMonthMar = data
                }catch(err){
                console.log(err)
                }
        },

        async getBillviaMonthApr(){
                try{
                const { data } = await catalogApi.getBillviaMonth(this.$axios,4)
                console.log(data)
                this.listBillviaMonthApr = data
                }catch(err){
                console.log(err)
                }
        },

        async getBillviaMonthMay(){
                try{
                const { data } = await catalogApi.getBillviaMonth(this.$axios,5)
                console.log(data)
                this.listBillviaMonthMay = data
                }catch(err){
                console.log(err)
                }
        },

        async getUser(){
                try{
                const { data } = await catalogApi.getUser(this.$axios)
                console.log(data)
                this.listuser = data
                }catch(err){
                console.log(err)
                }
        },
                async loadListCustomert(){
                try{
                const { data } = await catalogApi.getCustomertSP(this.$axios)
                console.log(data)
                this.loadListCustomertSP = data
                }catch(err){
                console.log(err)
                }
        },

        async sale(){
            const mar = await catalogApi.getBillviaMonth(this.$axios,3)
            this.sumbill = mar.data
            await this.$axios.put('/api/ChartBills/4', {
                    chartId: 4,
                    chartMonth: 'Tháng 3 - 2021',
                    chartSumOfBill: this.sumbill.length,
            })
            const apr = await catalogApi.getBillviaMonth(this.$axios,4)
            this.sumbill = apr.data
            await this.$axios.put('/api/ChartBills/5', {
                    chartId: 5,
                    chartMonth: 'Tháng 4 - 2021',
                    chartSumOfBill: this.sumbill.length,
            })
            this.$router.push('/sales/salesChart')
            const may = await catalogApi.getBillviaMonth(this.$axios,5)
            this.sumbill = may.data
            await this.$axios.put('/api/ChartBills/6', {
                    chartId: 6,
                    chartMonth: 'Tháng 5 - 2022',
                    chartSumOfBill: this.sumbill.length,
            })
            this.$router.push('/sales/salesChart')
        },

        async money(){
            const mar = await catalogApi.getBillviaMonth(this.$axios,3)
            this.sumbill = mar.data
            await this.$axios.put('/api/MoneyCharts/4', {
                    moneyChartId: 4,
                    moneyChartMonth: 'Tháng 3 - 2021',
                    chartSumOfMoney: this.totalviaMonthMar,
            })
            const apr = await catalogApi.getBillviaMonth(this.$axios,4)
            this.sumbill = apr.data
            await this.$axios.put('/api/MoneyCharts/5', {
                    moneyChartId: 5,
                    moneyChartMonth: 'Tháng 4 - 2021',
                    chartSumOfMoney: this.totalviaMonthApr,
            })
            this.$router.push('/sales/moneyChart')
            const may = await catalogApi.getBillviaMonth(this.$axios,5)
            this.sumbill = may.data
            await this.$axios.put('/api/MoneyCharts/6', {
                    moneyChartId: 6,
                    moneyChartMonth: 'Tháng 5 - 2022',
                    chartSumOfMoney: this.totalviaMonthMay,
            })
            this.$router.push('/sales/moneyChart')
        },

        async user(){
            const mar = await catalogApi.getUserviaMonth(this.$axios,3)
            this.listUserviaMonth = mar.data
            await this.$axios.put('/api/UserCharts/4', {
                    userChartId: 4,
                    userChartMonth: 'Tháng 3 - 2021',
                    chartSumOfUser: this.listUserviaMonth.length,
            })
            const apr = await catalogApi.getUserviaMonth(this.$axios,4)
            this.listUserviaMonth = apr.data
            await this.$axios.put('/api/UserCharts/5', {
                    userChartId: 5,
                    userChartMonth: 'Tháng 4 - 2021',
                    chartSumOfUser: this.listUserviaMonth.length,
            })
            this.$router.push('/sales/userChart')
            const may = await catalogApi.getUserviaMonth(this.$axios,5)
            this.listUserviaMonth = may.data
            await this.$axios.put('/api/UserCharts/6', {
                    userChartId: 6,
                    userChartMonth: 'Tháng 5 - 2022',
                    chartSumOfUser: this.listUserviaMonth.length,
            })
            this.$router.push('/sales/userChart')
        },
    },
}
</script>