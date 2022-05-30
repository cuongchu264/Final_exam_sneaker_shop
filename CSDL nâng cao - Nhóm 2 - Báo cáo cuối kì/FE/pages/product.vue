<template>
  <main>
    <div class="container-fluid">


      <!--HP title-->
      <div class="text-center mt-2">
        <h1>" SẢN PHẨM "</h1>
      </div>
      <div style="text-align:center;">
            <input  size="md" class="mr-md-2 text-center mt-3 mb-3" type="text" v-model="search" placeholder="Search">
      </div>
      <!-- product-->
      <div>
        
        <b-tabs v-model="tabIndex" content-class="mt-3" align="center"  active-nav-item-class="font-weight-bold text-uppercase text-success" pills card vertical>
          <!--Nike-->
          <b-tab title="Nike" active :title-link-class="linkClass(0)"  >
            <div class="mb-5">
                <span  style="float:right;">Sản phẩm: 
                  <select v-model="pageSizeNike" placeholder="Page Size">
                    <option value="6">6</option>
                    <option value="9">9</option>
                    <option value="12">12</option>
                  </select>
                </span>
            </div>
            <div class="row">
              <div v-for="(product, index) in NikeOfCurrPage" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center"
                  >
                <item 
                  :product="product"
                />
              </div>
            </div>
            <p class="text-center"><a v-if="pageIndexNike>0" type="button" class="btn btn-success" @click="gotoPrevNike()">Prev</a> Trang {{pageIndexNike + 1}} <a class="btn btn-success" :hidden="pageIndexNike> cantGoNextNike" @click="gotoNextNike()">Next</a></p>
          </b-tab>

          <!--Adidas-->
          <b-tab title="Adidas" :title-link-class="linkClass(1)">
            <div class="mb-5">
                <span  style="float:right;">Sản phẩm: 
                  <select v-model="pageSizeDas" placeholder="Page Size">
                    <option value="6">6</option>
                    <option value="9">9</option>
                    <option value="12">12</option>
                  </select>
                </span>
            </div>
            <div class="row">
              <div v-for="(product, index) in DasOfCurrPage" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
            <p class="text-center"><a v-if="pageIndexDas>0" type="button" class="btn btn-success" @click="gotoPrevDas()">Prev</a> Trang {{pageIndexDas + 1}} <a class="btn btn-success" :hidden="pageIndexDas> cantGoNextDas" @click="gotoNextDas()">Next</a></p>
          </b-tab>


          <!--Vans-->
          <b-tab title="Vans" :title-link-class="linkClass(2)">
            <div class="mb-5">
                <span  style="float:right;">Sản phẩm: 
                  <select v-model="pageSizeVans" placeholder="Page Size">
                    <option value="6">6</option>
                    <option value="9">9</option>
                    <option value="12">12</option>
                  </select>
                </span>
            </div>
            <div class="row">
              <div v-for="(product, index) in VansOfCurrPage" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
            <p class="text-center"><a v-if="pageIndexVans>0" type="button" class="btn btn-success" @click="gotoPrevVans()">Prev</a> Trang {{pageIndexVans + 1}} <a class="btn btn-success" :hidden="pageIndexVans> cantGoNextVans" @click="gotoNextVans()">Next</a></p>
          </b-tab>


          <!--Convers-->
          <b-tab title="Converse" :title-link-class="linkClass(3)">
            <div class="mb-5">
                <span  style="float:right;">Sản phẩm: 
                  <select v-model="pageSizeCon" placeholder="Page Size">
                    <option value="6">6</option>
                    <option value="9">9</option>
                    <option value="12">12</option>
                  </select>
                </span>
            </div>
            <div class="row">
              <div v-for="(product, index) in ConOfCurrPage" 
                  :key="index" class="col-12 col-md-4 mb-3 text-center">
                <item 
                  :product="product"
                />
              </div>
            </div>
            <p class="text-center"><a v-if="pageIndexCon>0" type="button" class="btn btn-success" @click="gotoPrevCon()">Prev</a> Trang {{pageIndexCon + 1}} <a class="btn btn-success" :hidden="pageIndexCon> cantGoNextCon" @click="gotoNextCon()">Next</a></p>
          </b-tab>
        </b-tabs>
      </div>
    </div>
  </main>   
</template>

<script>
import item from '@/components/index/ProductItem.vue'
import catalogApi from '@/api/catalogApi'
export default {
  layout: 'default',
  components:{
        item,
  },
  data(){
    return {
      perPage: 3,
      currentPage: 1,
      slide: 0,
      sliding: null,
      tabIndex: 0,
      listAllProducts: [],
      listCategories: [],
      listCarousels: [],
      listNike: [],
      listDas: [],
      listVans: [],
      listCon: [],
      search:'',
      pageSizeNike: 6,
      pageIndexNike: 0,
      pageSizeDas: 6,
      pageIndexDas: 0,
      pageSizeVans: 6,
      pageIndexVans: 0,
      pageSizeCon: 6,
      pageIndexCon: 0,
      branchId: '',
    }
  },



  async created(){
    await this.getAllProducts()
    await this.getNike()
    await this.getDas()
    await this.getVans()
    await this.getCon()

  },
  computed:{
    //nike
    filteredNike: function(){
      return this.listNike.filter((product) =>{
        return product.productName.toLowerCase().match(this.search.toLowerCase())
      });
    },
    NikeOfCurrPage: function () {
      return this.filteredNike.slice(this.pageSizeNike * this.pageIndexNike, this.pageSizeNike * (this.pageIndexNike+1))
    },
    cantGoNextNike() {
      var totalPages = (Math.floor(this.NikeOfCurrPage.length / this.pageSizeNike)) + 1;
      return totalPages;
    },
    //das
    filteredDas: function(){
      return this.listDas.filter((product) =>{
        return product.productName.toLowerCase().match(this.search.toLowerCase())
      });
    },
    DasOfCurrPage: function () {
      return this.filteredDas.slice(this.pageSizeDas * this.pageIndexDas, this.pageSizeDas * (this.pageIndexDas+1))
    },
    cantGoNextDas() {
      var totalPages = (Math.floor(this.DasOfCurrPage.length / this.pageSizeDas)) + 1;
      return totalPages;
    },
    //vans
    filteredVans: function(){
      return this.listVans.filter((product) =>{
        return product.productName.toLowerCase().match(this.search.toLowerCase())
      });
    },
    VansOfCurrPage: function () {
      return this.filteredVans.slice(this.pageSizeVans * this.pageIndexVans, this.pageSizeVans * (this.pageIndexVans+1))
    },
    cantGoNextVans() {
      var totalPages = (Math.floor(this.VansOfCurrPage.length / this.pageSizeVans)) + 1;
      return totalPages;
    },
    //conver
    filteredCon: function(){
      return this.listCon.filter((product) =>{
        return product.productName.toLowerCase().match(this.search.toLowerCase())
      });
    },
    ConOfCurrPage: function () {
      return this.filteredCon.slice(this.pageSizeCon * this.pageIndexCon, this.pageSizeCon * (this.pageIndexCon+1))
    },
    cantGoNextCon() {
      var totalPages = (Math.floor(this.ConOfCurrPage.length / this.pageSizeCon)) + 1;
      return totalPages;
    },
  },

 
  
  methods :{
    gotoPrevNike: function() {this.pageIndexNike -=1},
    gotoNextNike: function() {this.pageIndexNike +=1},
    gotoPrevDas: function() {this.pageIndexDas -=1},
    gotoNextDas: function() {this.pageIndexDas +=1},
    gotoPrevVans: function() {this.pageIndexVans -=1},
    gotoNextVans: function() {this.pageIndexVans +=1},
    gotoPrevCon: function() {this.pageIndexCon -=1},
    gotoNextCon: function() {this.pageIndexCon +=1},
    //All
    async getAllProducts(){
      try{
        const { data } = await catalogApi.getAllProducts(this.$axios)
        console.log(data)

        this.listAllProducts = data
      }catch(err){
        console.log(err)
      }
    },

    // nike
    async getNike(){
      this.branchId = JSON.parse(localStorage.getItem("user"))
      try{
        if(this.branchId.branch == 1){
          let data = await fetch(`https://localhost:44331/api/Products/viaCategoryId?CategoryId=1`);
          this.listNike  = await data.json();  
        }
        if(this.branchId.branch == 2){
          let data = await fetch(`https://localhost:44318/api/Products/viaCategoryId?CategoryId=1`);
          this.listNike  = await data.json(); 
        }
        if(this.branchId.branch == ""){
          let data = await fetch(`https://localhost:44389/api/Products/viaCategoryId?CategoryId=1`);
          this.listNike  = await data.json(); 
        }
      }catch(err){
        console.log(err)
      }
    },
    // das
    async getDas(){
      try{
        if(this.branchId.branch == 1){
          let data = await fetch(`https://localhost:44331/api/Products/viaCategoryId?CategoryId=2`);
          this.listDas  = await data.json();  
        }
        if(this.branchId.branch == 2){
          let data = await fetch(`https://localhost:44318/api/Products/viaCategoryId?CategoryId=2`);
          this.listDas  = await data.json(); 
        }
        if(this.branchId.branch == ""){
          let data = await fetch(`https://localhost:44389/api/Products/viaCategoryId?CategoryId=2`);
          this.listDas  = await data.json(); 
        }
      }catch(err){
        console.log(err)
      }
    },
    //vans
    async getVans(){
      try{
        if(this.branchId.branch == 1){
          let data = await fetch(`https://localhost:44331/api/Products/viaCategoryId?CategoryId=3`);
          this.listVans  = await data.json();  
        }
        if(this.branchId.branch == 2){
          let data = await fetch(`https://localhost:44318/api/Products/viaCategoryId?CategoryId=3`);
          this.listVans  = await data.json(); 
        }
        if(this.branchId.branch == ""){
          let data = await fetch(`https://localhost:44389/api/Products/viaCategoryId?CategoryId=3`);
          this.listVans  = await data.json(); 
        }
      }catch(err){
        console.log(err)
      }
    },
    //converse
    async getCon(){
      try{
        if(this.branchId.branch == 1){
          let data = await fetch(`https://localhost:44331/api/Products/viaCategoryId?CategoryId=4`);
          this.listCon  = await data.json();  
        }
        if(this.branchId.branch == 2){
          let data = await fetch(`https://localhost:44318/api/Products/viaCategoryId?CategoryId=4`);
          this.listCon  = await data.json(); 
        }
        if(this.branchId.branch == "")
        {
          let data = await fetch(`https://localhost:44389/api/Products/viaCategoryId?CategoryId=4`);
          this.listCon  = await data.json(); 
        }
      }catch(err){
        console.log(err)
      }
    },

    onSlideStart(slide) {
        this.sliding = true
    },
    onSlideEnd(slide) {
        this.sliding = false
    },
    linkClass(idx) {
        if (this.tabIndex === idx) {
          return ['bg-success', 'text-light']
        } else {
          return ['bg-light', 'text-secondary']
        }
    }
  },
}
</script>
