using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	class Advent2017
	{
		const int NUMBERLIST_SIZE = 256;

		private readonly string input1 = "61697637962276641366442297247367117738114719863473648131982449728688116728695866572989524473392982963976411147683588415878214189996163533584547175794158118148724298832798898333399786561459152644144669959887341481968319172987357989785791366732849932788343772112176614723858474959919713855398876956427631354172668133549845585632211935573662181331613137869866693259374322169811683635325321597242889358147123358117774914653787371368574784376721652181792371635288376729784967526824915192526744935187989571347746222113625577963476141923187534658445615596987614385911513939292257263723518774888174635963254624769684533531443745729344341973746469326838186248448483587477563285867499956446218775232374383433921835993136463383628861115573142854358943291148766299653633195582135934544964657663198387794442443531964615169655243652696782443394639169687847463721585527947839992182415393199964893658322757634675274422993237955354185194868638454891442893935694454324235968155913963282642649968153284626154111478389914316765783434365458352785868895582488312334931317935669453447478936938533669921165437373741448378477391812779971528975478298688754939216421429251727555596481943322266289527996672856387648674166997731342558986575258793261986817177487197512282162964167151259485744835854547513341322647732662443512251886771887651614177679229984271191292374755915457372775856178539965131319568278252326242615151412772254257847413799811417287481321745372879513766235745347872632946776538173667371228977212143996391617974367923439923774388523845589769341351167311398787797583543434725374343611724379399566197432154146881344528319826434554239373666962546271299717743591225567564655511353255197516515213963862383762258959957474789718564758843367325794589886852413314713698911855183778978722558742329429867239261464773646389484318446574375323674136638452173815176732385468675215264736786242866295648997365412637499692817747937982628518926381939279935993712418938567488289246779458432179335139731952167527521377546376518126276";

		private readonly int[,] input2 = new int[,] {{278,1689,250,1512,1792,1974,175,1639,235,1635,1690,1947,810,224,928,859},
		{160,50,55,81,68,130,145,21,211,136,119,78,174,155,149,72},
		{4284,185,4499,273,4750,4620,4779,4669,2333,231,416,1603,197,922,5149,2993},
		{120,124,104,1015,1467,110,299,320,1516,137,1473,132,1229,1329,1430,392},
		{257,234,3409,2914,2993,3291,368,284,259,3445,245,1400,3276,339,2207,233},
		{1259,78,811,99,2295,1628,3264,2616,116,3069,2622,1696,1457,1532,268,82},
		{868,619,139,522,168,872,176,160,1010,200,974,1008,1139,552,510,1083},
		{1982,224,3003,234,212,1293,1453,3359,326,3627,3276,3347,1438,2910,248,2512},
		{4964,527,5108,4742,4282,4561,4070,3540,196,228,3639,4848,152,1174,5005,202},
		{1381,1480,116,435,980,1022,155,1452,1372,121,128,869,1043,826,1398,137},
		{2067,2153,622,1479,2405,1134,2160,1057,819,99,106,1628,1538,108,112,1732},
		{4535,2729,4960,241,4372,3960,248,267,230,5083,827,1843,3488,4762,2294,3932},
		{3245,190,2249,2812,2620,2743,2209,465,139,2757,203,2832,2454,177,2799,2278},
		{1308,797,498,791,1312,99,1402,1332,521,1354,1339,101,367,1333,111,92},
		{149,4140,112,3748,148,815,4261,138,1422,2670,32,334,2029,4750,4472,2010},
		{114,605,94,136,96,167,553,395,164,159,284,104,530,551,544,18}};

		private readonly string input4 = "vxjtwn vjnxtw sxibvv mmws wjvtxn icawnd rprh-fhaa qwy vqbq gsswej lxr yzl wakcige mwjrl-bhnlow huqa gtbjc gvj wrkyr jgvmhj bgs umo ikbpdto-drczdf bglmf gsx flcf ojpj kzrwrho owbkl dgrnv bggjevc-ndncqdl lncaugj mfa lncaugj skt pkssyen rsb npjzf-kdd itdyhe pvljizn cgi-jgy pyhuq eecb phwkyl oeftyu pyhuq hecxgti tpadffm jgy-zvc qdk mlmyj kybbh lgbb fvfzcer frmaxa yzgw podt dbycoii afj-zfr msn mns leqem frz-golnm ltizhd dvwv xrizqhd omegnez nan yqajse lgef-gbej rvek aehiz bgje-yej cphl jtp swe axhljo ddwk obwsq mnewiwu klddd-ipiev henods rpn qfpg gjfdgs zcpt sswab eosdhn teeil-gzje ydu oiu jzge udy sqjeoo olxej-mgn gox tcifta vzc lxry gox gox mvila qdl jipjnw dvu-hxk xhk unhdmdz yomze povrt nbww bxu qqsqc rvuk tgffy twddm-fyx fyx nzkm fyx-ymnoc zogudq yncom tqrob sidvy dfuu ccjpiej yidvs-bxebny akknwxw jeyxqvj syl cedps akknwxw akknwxw zpvnf kuoon pnkejn wqjgc-kcebrkj zmuf ueewxhi mgyepbr nleviqc dez-argavx fqguii gebohvw klnrq rkqnl goevhbw-ywqi abwi eswph nlplbl pswhe lnqx fpgk lllnpb-abpb mpkw ampey yapme xnuyj-tmuaq asd bhbs sqmbsnw wsbnqsm ydwdncn rpa vrllkh-dnltf cck djy ydj-wywwl scezo clowuz dkgqaj dohyzcp-diimshr vlmsnlj whqb dkicau ckdaiu terp kgcii npqc vvzrqzv nol-wfpxe sqf tbb ruqpcq zfgb-kajykuz tsxgtys vuz kglmgg ihnnn plyjxj rcrvo mij plyjxj jqiur-pxs hmet dwgvd mvhkvn cjxg yvid vmhnkv kwxz rfemsua wdgvd okixk-lzwxas ddtyeh ivyama crrhxdt hedytd jfw-vjfv oyd fvjv kfwlj mradbx mckseee xradmb-llga yytxyvj lstspek lstspek lstspek-fabgf wgop fabgf bvsfoaw-grqnbvo tntomdw hizg tmotdwn-mau ufkw cxfi rhehj ebe xyv rhehj acxngo arl qtl rhehj-kbkto stqjtm tpcwshj saerkrt pffj dthp pfjf axc gwmmfdw glnqtdy xmskw-veff zqm hzhxap lgwnwq twsdk mqz xbbarbv cdx fhnwt qjcji bbvbrxa-fjw eds hofskl nkbsv des hvx xyn-qzort qzort qesz rtq oonk vwzlw wapoj ifr cta-pja hvy nhjg paj smtfe fmtse-xvi tcjj xvkjtab nqftt aumijl xkd cmilegf hvsmodx uuo igmcelf mslkq-mdhezgv lelzy kzfvsqu hvmvaxw pxiqjc hvmvaxw kzfvsqu-hsicsav csshrhx znojm eapi lhmzq bbwnz seao gfk azk-pup xtgjyzy wqt ijeektl-ktwh qdegzs btj pfwzzho-xdkmdm izqtjrr iqbke vtp-fmrbpdr zpccv tmtwx tmtwx tmtwx bys-ehphfgq idd ehphfgq ehphfgq uphe hvrc jcscne nbnslqy-xzqucgj fcih fljk barz lvln hcfi azrb-cmfmclv mfgvifw rnxgn jpg bsnq wnduzj ymsdx smdxy pqomf-rlqsm qrsml emts qsmcowv scmvwqo-tshzkpa zwtpda ftsiwo nil tpawdz kjpa ptzashk-mnep sfc swjawtd vnwud gyulluw zpa kmwyvln evd btnmoi dnwe-jwq scepq redoxmw rbdzsa wlkzso kxpm bttg vxuc moxwdre ijtdd rzsabd-wpvo dsjox amuwjm pls lgwksva ctakgpl rmsjj lzwwpr zzm udg-bji obbn tmwyc afpmkxr glvrd kahhgpq rna qkxyntp vmd mloshc-ymq rtnr nxjzm pqiddrn qmy vgxw ull-mmzk ikge zhtzhs xyo qwe lll gjjm icetq qgrr mzwqa knec-kxomfck idlh xrbowo nyetbnl qskh xuwkkxe upmmmf zhvuyp-srcwyhl czgr xmhuws jueyh xcuib xhsuwm bxuic-crkueh beyxopz xpyozbe dxgadw qktmce rjropjg-lbktun imdpcp fkssp fhcpt fehho jqdnt aoewa-jmun pynzjo trs ijwcc pelf oft pcsqdxg zvql-mneaaq vjrg jidlrzz phd mvxpivd ldkhu-sao xqw nrukn gatkz quscpsx vmz oscoeb-goi wzxhb rrk aylqqcd mlcbvvf ororn heptid kdu byevr-qsj lsbieef deez vzwdx hez iwd-lmgfb keqt mqbsuis ogrr errbi xiqe xsszacp-ato hmk zfjaj kmh plxup cida dqd pfwh nkbxvpr buajw pxkrvnb-cli bdwu vrwott vowtrt grle-zisgks ciuaqr zvk tcb kvz ugmtv-oegrojm wofpwp gnaocx rweyull ellhwow dtefylf dqsz oiw varr bcirpf oxusz-oydkmib oydkmib yefts gbl gbl-sruwjk pgkrp kea gppkr zdcky cfljh-obpxbax jhpcrj slcsa lgd fborz vvpaus wsrpsws ifijuzo-rixz jwh uhdaf hoacv hdfua-kntk qprmfow kntk tbmcjx-vnqe ooyxtb ixl hdmnpn orpz ykspl xromvj kowtq wmho gquos-ynk xjjqw sut lmtub bmtlu zdo dztlk bpkuul smhpx rbczg-zals csdbe sbj dibicq kdfwwt-coyy pjddlfc lwvhyms ldjdcfp ryubz kfwst dqjrjja jtv jjjaqrd-jaexhms iqoiln ewgyr exmnrr fsr lgmyy fdofhn-pjgyn hfoz zbcnz nczbz-ovntivq vcey vdrkse giu ohyaxy ionyy fvpn yvwrgrv qta-yelpz htbk njgeyub tggh mdthzp fwyux rduqli twlhfp pnh gywif ttn-yxhsbil vplsmmx rgtq grsf lyibxhs hctnkfr awg lmloz jroy lpgb wga-kzytass szyksat tyskasz ehmhhu-jkus hwjv ymnnkk yffugg cvtnits gbl lywkn szihcn dbrbalf rxqpbqh-koyfcef wkom mwok qgjrytl-slmhry lcr slmhry lcr-mvoxbt cfkz purnsui xar ouhtc thbx-xcdifw kvvxyrj knac qmypw bou tmukqy eusgaoo bktiu-ablgnhb axumg bwpxnjp zqpc vtw ghhoxu zqpc znfpvl ghhoxu jlg ntdk-vmvc cdkhrx cvz rvxk mmcuo udpcayd lsmm gufduzt linj-mgyeqkv hqionh rgnqgz kkc qrgnzg egkmqyv topdp-koa dimwx gjxa atlfdy-uuez ueuz zeuu ezo daq-ofpaw bgomvmt mqa dexpy mbipd epyzcoa nuwrh vwly xppz qkjrleo rwhnu-wok grxk lchvtg plrzr lwaax cfeu ijapws dmkdwc cfeu-zkd hysxxip hlydw wicsvy gbwoaw dapre ktjn dzg uri-blzh hblz qgmjceg fyf-vkhpn xnc ogva pjrh cxn hkpnv-aja cldzta tdcazl lorr fwmxxh knilf ges tdhp gnlo vihrl-ucpr peair nlbmc msfg-trv ppq bmo xqd vbui yegsr xqxawu fvuz aclhspo wnan-loiq fvg kare rmgq hir rzo ossd ziw renh ygtkjys vda-xmans kio alexs ujekfl vvf ddghn-fcxvsf bjuytet zrzsobo uhn mlfzhlq bjefs-zys htlqvky plno pbcqfuf fjwc vshkxrl lonp lyzmy dqmui vyyc glad-tlc krhcter krhcter bolk tlc opryl-idcii dverl uswb wusb zgax zhbt gjsnlso yhs-cti npri rcbxjdw ollj nirp ghfvxzh-blyhug aflnrrz zudyw ccnstq cyoju jxtqoj ntuknjq gunjiwy ycuoj igac cqctns-bul yehpnw jifjrhc ifetu ufrodp hqzpeqf hdvpc qtvgxg ibb wcxsitx xztshb-xzct scetn eoaufyo jtudgkx xrpgxip lpubtq juezstc nuc hokswh obkf ipbu-nfq lwpmn qltal xnphsqs zlrgf iewtrtd mqzsob duokpy kfbqs icg-vil zjz xkqrvni uay ystq-terrrnt lnfg clm lbs ptpiy ybcuup ayzjm pqugx lmc yppit mbf-dtajh vqivg vnblt fmn qxkw stiwna pclrrr fro khu wbslnqp tjyosu-uqlehn tjuiy obt uedct bbwiq uxndqn-hiqfovy xiimca zwne ivunvjk cmctzi mxnnrx dclib xzaoq ieztkg-shpr xuorihj chuwq poadbo mhtvex gymsp iltgl sypjfua fmyh sgiv-alv nxjt txnj bhact-vjvtrex obmrxk fgigs meixbc fggsi awi rxdjpeg-ypwo oicmbdw xbpeeyj uabzj cjvutvc oicmbdw immtmks-exijri hogl epr gzdqyur xiiejr pre ihzlgzu-rlh qfhx lrh qmvrx-kogq okhd mivmivb mivmivb okhd-taekt nhjaa znbaahn iaospxy jawwf-ytdvq ghtqwud jkiig mre kzmmjxu jba nwpykc-ktyzr aczd exgadhb uinrgac izazxky yyfe-yrifb qgc lsiuapg teyelxn ugezu-wdzkc ltx fkhncb hwrecp kfbchn sfcpc hjvq-rjdjyt ahwxh nvggsmx lmz oshd xbcik powse ahhxw yhiq gxmgsnv-qdr qjnam gag qjamn kooek mqnaj-pza gml opf ilfbblu kjp luilbfb rhfrzgp ixagj ofp-yphz runy dhull bozcsgk wfxekrd akgkbz urcphc-tfyxwol lhcl npik beug-szatel yfkve yfkve lzqhs-yjzqon pcjibu bdncmcl kczuymm pbmg nyn-rerqvs aoxucwi pmstl sstawu joqu abvcchg mvgjn mslpt vhmfkr utusuh-gqbec jjpqdh yeaiavi nledfi jhzwc vyxjpf momnm vnknjs nvgjzik ipm-psirt rispt lrkgma irtsp-jbbaph xvunete gsvnr mjd ifxhpry cpsx hmuokkx vhcm yth shrrl zbhd-gfa bcmlxtf sqyanrp cugg qxfvftz pbl ujsgc jajxltm gugc oil-xjuhyg aht vmyvzhh oby oyb ybo xbybgmx-atfk qjudfzz mky tfy-nxk yzy jqgg qxgjt bevvvv efi xcbw bohc zaqlqjq-hdc qpnx ygmtqw acvoa udboxw dhc klh mwgpk xfpuri-cycgbkq skwhyf skwhyf veaqss skwhyf-jnezf jowjt vsdu uck scgxd fvopomz vfajslp-djvi epgkyqn apzd cpm owm kpwih fsr adlhqu jicp pmc-erxlmhj wqxvofi ugj ttrmtsb-omku vmrgoy tdicbje ewml dfnwbap-gpih pyt ptsmzc gmdbu rqxkqmz objm nurxjz oozbere ztxug koth-jpnl jpnl dmeh qed-intdwv ksgw qwlzhq zpd lrl mwjl dozrjwq aujbet bsnf vhqyg-eqs uot qyz xor aem kmrh mrhk jqx tsbrf-irytjab mdzm qbb kkjt gofiwo xgbovg kyeyxqn tcks tljhx-zgejy qodgah nqavvx xnigdvt-eqve bizrxq lkhz yzwxgt nwe zfe sxypkz xnssept-bxqn lkfg yfxbszo sphwifz wnj crhbq dvokzw-vzn afatwye ogzvnu vnz rfjba xtugnj kpbgly ocsjd-xrc cxr rahv yvhk khyv bed ctgbuq cmqwpqa jlbg hpj vmesvw-jbshkya dgqw lfl mzcch jxsg czcmh ifruvlw ufwrlvi xcczlol cqqchmr-rbk mhn tnmqdc sxnnn kvoa mhn sxnnn mgemob ieiyajs-cqi ghxg ghxg ghxg-uqwdxn qli gdtkngp gnptdgk udxqwn-dmcczr dnjaqc qwdta rhrbi hkdwe qdjcan peic iulaz xns-tcmppb nzq ecy sitdud nft ecy afrbf wvnc vmfpzx tcmppb cgb-plitv efnpq mjqav nrxxo izg lpitv rwbzdo rdbzwo-day dntga adtng agndt hhvtd-yrg iudsh gyr ryg-qttyeew tco flq bszw jkzftc wdh efcwnp mja rfmju-moch prkze uslzyv plhjuy kxczyq qlmm hgq-xtg ypz izy ixg bvs xlqgj xcy sepza abiylsg-wxvsxn bqag jnlzgxq ikxwa dfd plqxl xlgqnjz nuqvoyb emhodso gaqb-bzjdsm xmxkj fhuqn gauyw ntl kjxmx zcxdr vrds-ofjcc uxyzlk ofjcc ofjcc-zwosex kkvwobl cpudsmb kes zklf bayuojr otqnyr udbbs-iqpvzh ybds piovrh oivprh voprih pov sfl-upns cpeelht xboyk itb hsxdmt dnwgfbw upns fygf kwdpxzm mli dyy-djwutl sikh shki ikhs gecd jqkon trqyw-prbbdf vdp bvvfjcg ydqb muxygg-vhpurzn psemqe xwqfk hrvonxu nxkxacq-xicmhss tnpja qiad woipfy uvadcq usljh hzgs jntvfv wzikk-mmupc twntp upcmm pumcm-qnisuzy lppnfd uiqr eyqbain uxlp eyrfwjo olgkrps sbikam zin vckr-nmokl skfni jcdfot njzqeaj nqzjjea-slmaxx offfzqp wudicrf nfn rwfcdui cwirufd-paffi murnjd oyj lbtjdqe babuas dtqh qkt stapzl yrqlp-eedc rig zmnfmn edec ecde-bcfdf edovdj lacx nzvze sordvxj ybs ujh zvvvp rzstejg ueosuq-xrrfsd okuvem znzlvmb jwzcb bfg bmuxbc qzwfry-pqgxybd cvgra acgn ocd ancg fvfcx fbb bfb zfzv-tmmv mpywyg fwl bnvcv lcnv flw-xxnfbro papc ianru beuzx apcp rnt-wuyhycj nrnc cka ebg rncn rvo wcyhjuy-thh cmoog hwf imqfp okzpxd-rzxiqt rtaiy ytria tyria-cjkmro myif myif xyirn aqxlol wlhwibi dhzsen pzwgm bfbz bufjs qwffg-mxhiui umiihx zomyll vfieccs-yyntf rjk iivgj mwh rjk-dsshx wsmaxhc xcwuelh rdsgtr wsmaxhc rgtsfj-rdh nwlxiwu xsjzbpr bsgps-ufyo vqtzkg kpeohu mxzt fyuo gawgaq youf-hzbhut bxsnjwb zuhhbt zhhtbu-pdz sgntypg ragev hrrji goitft yphnebs xjzoo sqf jsuzijq dsocb hcxg-pptsq woomypc woomypc woomypc-axcg wfbnpql ejqb cmnn nncm csvlc wraludb pkmp whtht tfpicer-moom oomm ommo vfqeii-xvrgpp rofl yxyrkb oage nypzau pwfnkn jxnhkw cyxsi clzb adwpuh-mfbz vdtt muzhm wvwwfl ttdv-cpqgvbu byc pgfrlkr aftl tqm zcqxi juu gnf ppovxh huoa-konpcp lzordid jqng lwxs nqgj gghkxmf kyn ngqj-iorhccj xfygc cnfr tysqc xpcyf vmjpitf nut zmrk mgbrtb tcblxwf dkadwrm-kov jtmp xoatesx qxkilp rmggpfx ltpxzwf vko reqms mqq nps-hjigmk fyqy wpuwe mwmso thsimfs okcmeyh mzqkez duzaq vzhyrm uyvpkox cwivpls-ukoerf korufe zhs ntwfz hugem vriyk enfaib hrrcdgf zllsk vkiyr-shkx khxs wntpjv qdevaw noqyht nwpvjt egh hgok mukdjfi law bzbvjz-dquk kczxsq tdu trnkjs wqtdc ybvcb-hlrotxn cumcjkm qwufgle ylm nejh hnje pvaigrx myl sfvsd-szmvisn aywic vsnimsz iufmybr-zjozr zojzr qmn ffrggdh wam dafvok-nxkvlhr posmf posmf posmf zhlzb-ywis kpqpyb qae zqxpuz pcj hbsfz ejlwa lajew znuom-qxsl ussivur dstd avojo-yoeagao egpaqm ymzf kkauy ivm illir wsvchne skmamvn nqxc-cldo ixzzy vhk nra zhypgab-qjdd ecxud tbuqq mpotbdk tjdpczn knncm tyy-rbfc fhhjf innia tsjbbbv fmtcuup rapvhqz ebpzt whdbms gvjoy lykl fquvcby-bihhfwi lhal udxz uwjwp dmb-fekxamy uophet yzvv rqj zawlp ldrv mdymkzy taauf-rcwxvmh edueui ltdyo xfghz dgjig senm ifj-qcu fii axmgijj ifi oixjfsg jxagijm-sdtyr rbdh yvnvq czzuig wro-lot xkto cmpiena nht ozcg aotcw xiegl cyaouj und lsclep cexn-pgihljk cmgmv sajhi zfvbqij ogwoc ajsih zmppe-jexwkdp dwpexjk mzjydfu bff rubgdb-yshfhx emkl hshxyf mkle-dxgti jdo tkwprv pbxbrqd oiz gsbdphd qotu utfdnq tzvve bqc-ovdf bshfxyl xspjpd vljdsm mgkd djlsvm mlsjdv-etyia eytai sfq qafj xzgp ewhsn snwhe lhqp-zjz mwh dorxm ges gexo rckwsa dltoq mmntha-hqkuj ypsjcxo dixbe rmvnhjh ovnr-edc iffaxc lolu xwrvpb gva vti vit-ceuxq xbwejr lzyvm rozseit cwe mham fivpwj qtv omaktaw-alzdrk tsxbuld mdbq pgbdtoo xwf vzalric nqe jqwlxsy cbtylu dtubxsl lqm-rqjmjcs exjpn kpilcgu ihcm lfadjm mlri hpd vqs cxqwqhu twxrtk-aeuvlcp aubvnw riedvz arypagp uuvg kliehx cokt ogh xsdw cdsyywv-ddwrgvp bscaq bbfv qrbutp-jpdg uey eyu uyarl zgbk qyhqq fdvlql zmwkp-kbt bkt lebhpfu smrzt xalw mmwa zmtzfry tkb-fcvcv oewfzu fvvcc mldww lwdmw-ejrltsu sqoyx wfvsdbp bfdspvw bfir jqhgrmt ofdmrjg ysq-jzwucwn erqjd eikq knpf cvk xvqnscy eei wvfjzmj xujq cqaim boev-jqhkmr ipjpj zwno ybu krhqjm zqfyyzb dyciy-ugwsw rpwteje qtvwi pwyhrzt hfcdfmc qbovk ibws-ffy kdder qjookz bfvmvvq yjzuaj fvxllfb pjyz jcezhye fimyydt qjookz qjookz-loupd nwsc yytvuqo ltcqxnf-iho ulvxguz fxbf iqu ofjtmvq xhs ybbusd kxg mebdnah ucttcf zufb-wzdb wumuhtv kef aavv buu xmjtlur faaccl wospwff bjasr eapfsi-jau qzszci ciu inagax-kui tqig fyovsp fvwol fyovsp mzth tcp nhoq-ajdla wtpj amylu jly tvq wjqef-ofqc einz bdze tows bdze eew-avwavzt aesrsjv lbmpi hllv chdbul ezelxn-imcprs cafb clfg rsjo iylqu nvk vkrq izezlnu vkqr tyhnv-rwj zboui reh buzio wuhpvid cpzy jrw tsbuiby hmxwqr ute-ixq luwbi uoiwsjh souz ysoubw uilbw ffwjvw ewzswoh hci zmfdaov whowzse-xrhgqf xrhgqf giyv giyv-toiqgzv gakg udgdlb wvi carrn pjyha muqclu-wuxthi srtszr ourab hpds bakvy fnk yefe yfee doowxcx-ijdc ujhvls xmy hwg yetsda qelbe nang xgywo wgh-bhm icq cnam dec enksf qfctz pwxoo bdf cnma xoowp rbls-jguzh fextz yax kesaunn waljo jltcza tfzxe dezs syi ebwxnks-flvq bzgd clvqw ahtyvu xbdyv wssxx boscm grgl nqcg-caskpli hqctxxc nwpyo wjlqfqf ebti dva-wmsz fzpd ikgeq gti ejftoou ezs cqef mybojc rgwz-mdaay yfppa pavl fuuvfkh hpod tpb dhxmia emdecm rbqcwbk vecyt-neha rmvl ndp vlrm dpn debghi vyhvc-bnp zkxdu iqqkesd abtlx hmjasdq kyvekr krt srrjyd oxmfev oot-dumlcqd ccm hyir oritdz madjjw-oakqrs advfmu verrc zkfdcn btndsp-onlkinl rdtm bscfxre bnu oumyrvv kgc zkj-tfxfsgm uwmic agswclg uofezgc-wpfdyjn kjlihk etbot fbu scm gwccce xgownte wig cuaijbo-bzbdk etozk qracb oftfoo lkooe-xupzw vmxwu sis wzpxu-gbz oqbgh jwgrru bzg kwmxcfc jrurgw-agyjnyc tuec imxlult omwiyjg fiwnoqx nhmnro qtg kbr agyjnyc-koiq llreotu elrtoul dubfvgy whq-htm lll crzppb gdjaae nsmxzh gnfvn obiuy ymspzbo iuboy-thm xlfrr pbxdfo mht tygi sapxgbv mmngzf dej-eus seu qmstw ues-yvfsw esut biblze kbjcpk estu xih qzki ezlbbi blzv-ohq ugc tqqeo jygvpwm vfs ldnfibp ycbpa sml rmime-kuuow gbg nzwdaf wiimtg lam oqmm-wsbwkdd hda nqk ticz mvt-gqbljyh zqugqs cjod sxwlqy qkfs wwvwvt dsojb qbhjlgy riusoa uosari-jkphfx dbt les jsvoij rnuw mxmmchu dol vto swn-qqxe vwvephr twdqlyg cvdu xjiych clooq vkwavl whvverp yuz vkwval-txtbudi tiutdbx wqhx tws utgbf amh hmf izsez ooz-egdube nhsxjs nxjshs xoy sjsxnh-egdziod diodegz ejxn zogedid uhhkr rnm cyvvuc uqbl-rbn pinwag sidwdwv jqdbe jlbemk blkeaqq ipfqbtn zkrbp-bdryz sbh wxvn mhot wemsfm oemkff-vxyn xvdwwo xhd vyca zxjaw vfkz xhg ofsphks dyq mmzzd-yjrqsjf iiesdh envwyx rmtbmiv ggzsg ukx bprfym qmyqc vag ymho hjtoh-fuxxrd wbweptd vkoffr wbweptd-gfwcez smetli yjyh pslpz qyokpsm qsy cxjymg wqfkf obuq awz-eqhm ceest kayf heqm-rdi dti vntcf ewkmpvf jjwoihc-sfq qlb xrm ocy vtnj zdznbal zvon stln zwnj wsgalvq vhphap-pya jay mgnyo pya xmapdn-hrwbj xhr gvwl ktq ktq gvwl-rzgqi hjwtthl kxhggbl wepc hgavj ctmqug-tzfwkc xeqfath iiuwq iiuwq dhwuvy-gibagy smq getjofc lum msq ulm xuxu bilrus ily-xlv ndrkch hdcknr nqltoze xvl-wmc vuzlrj mwc atp cvpx atv ujatz-hxpafgl ymjltv nvvpy ahycdk jhpdcks ettm lvqyw ertpivm dnezwxx usi kdhcay-vrh hqyomv mcq ilwjbkz yprjxad-ugv szfitxg zeluib pfj ijm zmiigxx gltxzz jzljhgh otskue-mxp bilj jlbi tce yfted zxsqas ftyed-ykasqv ehye kirmnl upmi dojwmw wzj ykasqv ifixn vreoypz-kerbgub nnroqk onkqnr gbebkur tjhl knjo ccsem yozvrcg-ygq evkoj wkn ffljhds scxeibh egsybeg mwvi vgjblj qda ywqpp-hocvpl ozgkxp xgmj ejzyxm-gernu kks lxe nxzv sypg xle goz-xoatis fjp wzlbo dzkonz jtutyj vdonj swro tqclemv xhomap ymeqkua vaxcw-mxcyjs ywyxndk wng vpftv nsuvu-jmiyyhh gwser shgcu jmyg cjzegc hmhe eopg kmkan-smdd dmds mgqhtkh qtamih haqmit skkcy-dnj rmggy rgymg uburbao rymgg-klcpjgq ons ajyv sqryt son pjlcgkq xlobdt-piw shonk tzi mcdumz noskh tebolw yaypn-ozm mvmjgtg nxj weommiq asnmhzq xjn uobztuo cqgjh utfb oydt ommiewq-qlwgsc vvpe xgft ahpjc zjtx iyof scwqlg dxgcokx ltrefj xyzq rwto-ggqdd dqgdg ggdqd kjkmmfp-htzjam fjbg iagc xls iagc iydtf ihxl boa iydtf-vhe nqj bwgdoi hhaoa qtulz-axvyja hpdkwee hnryj prou rgadv oubjdqg knjbc-caz xibj wqkzwe peioeya vmz hesy ftb-dudwcr gupj sjrtzc xsqbb hiet nujv bebcvsj eks uuzlcx gex-kywozi tfzuc mflssw hnxxxqt zzc tzfuc hkokuv mnjg lwkavjp lvpwjak xez-izgh zfv cingjt dkf cknite qox vfz zvf-ojpu dzk tehpgnt gntpteh-glxfxa uxq ajtles ahgzn ajlste zwgc mrpu adz wuunwhc zda-hdgdtn hnoyz aromkb qujfv yjgmn tbf atw-uyvsv oaopjv uyvemxk ldpp tthe iisjk txr hebmd yxevukm rkziao znt-ypdr mnwuzvw acpg kzwz ywbn wcrr umrnlbe lkult ljify azyhu mgqoo-abmpl omsd xmyl mxyl mgoq kracrf ufm ppwi zpggh-uxfdpv jnm vvc vchunhl ubv ktj mxolsxz-fcja eci edzrb nlvksaw lhf ycohh tfztt xso ceub tyv-rkwtp tcmmvv kufg cxui hdamg suuaej fgku cvjlv-oldbgy riadoyo djsi wca zxoeq pmemqap aijxa-nyy ruxcosx xisqoz yny jvzfpbe tlfdiaj ybd jifatdl zuzv-kxwdz qvrvx svllp ergmme-swjfuv eronk favcxfm acptbh pnbjn ciqcrlt rgvdnlt icgahb-ddza xxfn use obqka bfzwjp gmf bld fyvde mxdfdl-ame bmxbyf ame bmxbyf-rdgby pyfog dybrg gdryb lpztd-sntg impd uxgxai naoalb ntnk xgix-oadpmqj oso criln izih oos-ouzjq gtl ito xefqt phnv ouzjq hoyjjj-mlp rboq lpm roqb whvp-tghcw ggshevw dzsgj ggshevw kec ggshevw-kmwhb kfcb mbhkw gemz fdh-euve veue kplrq evue-hikfiw bcdktj hcnawja gjasvwc vcht igrzly rkxijxe ikfwhi dvmp-hvksis kafs ktcs sfyqzyt etctrgt vodwr wff tskc juobnm-dpcsodn ehwc pglywfl yhdp mdiyzx-ibog umftejh cfm pnxhna wqwx yabnk ygws dqw-dezz tqw qism rarfe fpmlab xvbau irwtfs wwmoyss yvn xetqp xtqep-pchqwk npsmd jefec qok uuc ucnpz rlkakn-kudh rjysb xrdbx bkbmjfo xrdbx-rogu ssdwsus voa ncw obkxsr-tflf hlevus scq rrbpat tau wxsq wxoblt-rzr lex kqdy whtj ffnys xlgkkff msjhy dimaq hrc wyde qkwf-ghtwd wernjpn tdgwh olrfvmr edq gxvp-rjirvf skhdgln aauit bipu mubjiwp kowz gyjfbjx cmgdqs-aftfpbv agajyy aqjll vsf twh robpys lebt eav yribup-sby ymkla sxkbfwl awmd nhb vlp-kizvjj ycjswr jkzjiv vuy jijzkv jcs-cwvch xzqfal tephz lqfzax cnkbdcr mql zflaxq-jjxzwl himpra ssjf bibfiui seeaq pzse-jogrn jogrn sqew jogrn oixgwr-khonpyw iiyxir vybhc ndnxxv kzlt ipmncn-okqkqu svbemi nfn ovd xgwy edd ujet nrrbv dde vdo-jobvf dus asvio vaosi sovia-knmz qbz nkmz zmkn-isbmopr unduey impobrs hea zswciev sopbmri duuj-ocs ntgnrdu kbvtzp cvyieu fiyn znmh lhrz ixtnzrj vktbpz lbpqx vzkpbt-muduhc sabc dlyoisz kuaz ogpyepw yuog ictiiqt-xjflsf nfklvml thfh uajnmby cichyj xxoqi lpime bxpyx-riahifn bohbgd obhdgb jni qzvkf ybp hjkkwq ytutd cakcsh smfdoe tuytd-iddku nccp zgtl yne ppzpqcx lwm-refpcz uqt uqt uqt-mtn czxkagb nmt caqacrg bcakxgz-itxjii uethxbj vpds bsqod diqax inv zrwt doepe-bfyaj nbvhg zmi buf-dtre dkwdr nrapm qtfth odvt bbcnae vxuk gqm enlg-ybt qcfozrk yzrh bfp euuozuz pzsdkxx mhi nbkzprb-vpuhqn gyx caint antci vfep incat kqdakdx-ddhi chgnjk ibg xbemitr mjtdph eovw-ngbtuvq qdttlsg dbqhhwk bkrqze qdttlsg qdttlsg-evn smvhi dgcmn xjo ascc ahbpj uvzc pwn tung-ksu thr omg onvsqzz rllakar ysfjtfj grxwyx oawix gpk suk-qvb iouav yhtndkd vuoia ouaiv-kud kofcip hcczrgc cvvxxlk rvyamwe duthdzr dftun-rgv ynw gph tmxwfup nwy-dnc trawj kwzbx trawj zvp-ogqxijy tbqtsg tbo vqinnlq jbvgl sfafh rve mcxqs ubh-qccr lpv puuvdyb tydaflf uxic-tlon tbfwkxg tlon tlon-iytiz qjlqaqw uixb lnt zwro uzgxqfi gklgnqs zwgoidw iifk wkwdo-tmvhxw tmvhxw tmvhxw fhiqpjy ejk kvysd-cmphg xjjz groiccd dvetuk xbwa zhm lyi ohhd neg bxaw yil-kdmzopy lxx bvhach goxmxu qbqvzcm qbbrhvb nrfom aixmio grpxz hbrqbbv lkucih-bnqn phqr uycuxc mopyyfh bbpesqm stgigq stggqi cwtjm asqhpl imvlxj lbmloo-pws iuvbvjr cwccm qbr srqnstz cjebq-bfh jobkcy gtbroe lpagq icmax jobyck fbh-ounqdo qrrr pwi alho rrqr beao rsioepe-vrccqge qvcgrce cbslkjs qnclw rvmjkw-aaxjns deupjs wtgxtp penad depbho tbrdt depbho qxg zhjxpgd-drqfo kbp jfa jaf-izn oczcitj cpae quvzqo iwwk jck idjdpm-ecort zgcvxx bvh vrprsf-fhubfvy ndcfjo kol hyufbfv hvpka-kpt zgajpc rjvsxa gayznjd-xeoixk peq kfu lqa mjnv mzvh bicl hlfk-wyt imdx lksy twy-xeptp ilxs qbsqzwn rsy slxi xtpep dsdkekl-rotvbt fuirp elos ciu nhx bxej trmtx ixn xbpc vrxtma-skcprn yns sao ghlq vftezvc aaryahy telt-fkaov gexa xijv yiksa xega dhgw okfva gxxs edkecag mqbqvrm nrzcqub-ljc jujxeof fdj gdzjzr mabbktu pmyrfv uspven zxry snt hrah-nhujhdr jdhrnuh midm bbavhpp cpjk zmpbasz eptrpou znq zqn-ywzfq wuu lfflon uuw rke qzwyf hjbms gakx-yqrq zsk jzn uuuzrml kzs lseupsg waynfh blech-gwyqej weyjqg uwuje uujwe-lxud rnwkc bgygkh csq rfvtos ystqp keb gkakodj uthcce eqxifl-elvj evj rfwo vvgkosh aarcgjs utsbh orwf jxcqvmh uowmktl qtgf-bqszre oxntty ombwiz mbiwzo-ccp iilcc tacf czk giwv erqi jgdfah wip xtrzhv wosvbyb-gymyw rwsxeg gvydr izyk spsonkg knospsg-djj tbr tbr tbr ice-yyzh zkykapw puydtik ysxc hjumhsd cuhhw dnnhida yyzh lnklymg-nhbcxsu ccrbbyw scbxunh ghxrkqh brcwcyb-latdaav sexa ipzuzjl ayusb etb fshh-giz akqd vjmabii arfuzgv efrww jxkvolg efrww vrnzgbx-jmcc vqy adkzj fqrkdo tjrczp ccmj cfponk rptzjc-jsviu sraw imsj fujm cdf xwqhl lhz ojejzuy trtqblg-ibz dulm muoq quom etvjzxn tuhrpp jfukac jqctqn qhgbae msgmcit ludm-zgx bpfa elhp rnyqtq wyceube nkeuxz-lzxfo vygpecv jszacku zfxlo-cpmv ysaaj xnp wbvqg hrsiuj venjxna yeqvwmk ftaga dcqxc jgapb rqdixp-xpbbe tyn hfdlu fto wrgzkou sxylv cqto wdv xqc pnu rapk-pkrxypl wnu oipq tzbhnc gpug tgzf ofjb-mvaz bwcv gll itgcye dessw szt gzimgeu bvmohh wbywyhc kzerxbr anjsive-lhvnrzs qkmjwy pnyciwp mgp jfdz ghvtf yusfzg upab-xbscukx aubulj snbcmc uscxkbx ddpucyg-hgv ollh yzpjmpy fcicyae vhg gvh-prd onyd iux oik xui-zipadig nvewx cir lbpcusx dljqy-ifyxzsc btmy lsu tmyb lus ldyzx-egmyxbe ieasvek dylmj qahtatr uyqgbk-mejjczw spj vaekp kdud-vwan mgenld mnlged vpfuil euoxlr rclkpi dfknyoa rhthij kcyxl qaxab crlpik-pqm eihogk iwml nuauxi ngilkoh jmu mbdi cqxz nblb rmuj zczdgp-pswbe mtzch wbeps fxtnc psa aioff pas-prwrpvz oadpqvz tgzrt giom pjyihh rxdir dmya xjolzxv-khdybe obqkjn kdq jkvmgwo enpat wyw qjbnko waid msest wwkoyts-yep liv ofmtpod imdd qyw-afnrx jgn gxarpb myltj ggrsajy mdaobjo vbtn vbtn zlziz eds-hqr kqu oub skoeqk icnfm cqvld aay bto-rga odaf exoosh pwevx zpbd plaa xoseoh-mbr gqu oxvchrt nqa larxmjx pfozej-ozuo ywubjbg xcua eblwqp nfdvw hmhen zkjfu gmhgp bsyi ktprtf-src vrysby srybvy znwjm hmypwdl gdmau pqe-cldr crhi lbaq fbuduyn hygbz uhida-qrxukq dygkp oaks soka oask-vpido ajgfq pwlv hezt fmg epwrxo rqvjke iovpd hhkjm-anxf ydl xnfa hqph olorp-exydcg onxjm psqlbv ehz boar hze qsblpv-mnzrvc ipj swg ijp sgw gdkntsd fzz grqwly-erpq qghpj fay gci uglm afy-jwbq hbxaub jpdilyt yvalrlk topl qup-eczonk ftcc paltirb owz tihhe dglxory wthvqcb qdnxm lirejh alyxsr-ooruaby gboyeu lkv arrz jcqyzl uxlfk fhmeony fcmh-wzr xjb pwmf okqj adwcedy lkidve uwekxf asbdzr biub-dikhur pxgh urdinjh wednf ulzdxs-iplf byt tyt qnnlba pzt bednml ljjtkvo tjovlkj uwms xat-htzk ltmfha xikeze atfmhl fchxhyz-lqala bqwgcul vetaa xuxjau zcb wtdmomu wfqmpq sief uyblyz ahv-aytvvo awm ojaaigg awm dbfaokz-abq npcyld fzbfku oia qss jkxldm wgtmki pasgxi dieix rpqnuac tecnfy-nmr qzfj qjfz lsz vnahex-djxoo jzlkh svy xige-tjlkkg glcuvmh fwzlhi ecun qlgulj hrfhyql qgdlf ofakqdf zokkvm gelxkq oowgs-upfpk gfstjlv lxc rjd nhj sbq jpzsz zsjzp-favd nzqfdid nekfjsf mtjndu-sgdqx uvpuefv vhwrgd aivav gsqxd jdhfoq-llaf cthbgy njrpw fqgkx jzf xqkgf lnrfrm gkxqf-wzdwlc wisst alw kyjeur sjsqfcr tta bijnyn whfyoxl-dtjr baxkj lmnyrlg nrmyllg-mtgky xmwf zdko nnocxye gytkm ygp hixk xwmf-maudjy okgjga uadjmy dzfrk omd-azz ajdcqkd bcafn zaz dcjaqdk gylyzo-xzvfbf fopmfxu mvftgr mfupoxf coyhof talcc vpkslo";

		private readonly string input5 = "1 2 -1 -2 1 -3 -1 1 0 -4 -8 -7 -2 0 -2 -11 1 -2 0 0 -11 -17 -18 -1 -12 -21 -15 -24 -8 -5 0 -17 -8 -5 -24 -16 -16 -21 -5 -7 -13 -11 -2 -27 -29 -38 -2 2 -27 -10 -9 -32 -3 -1 -6 -50 -21 -47 -47 -16 -48 -19 -53 -25 -57 -42 -64 -21 -59 -3 -51 -66 -44 -42 -45 -6 -18 -28 -18 -48 -21 -15 -4 -10 -49 -72 -56 -47 -41 -74 -38 -60 -28 -10 -32 -1 -9 -40 -10 -6 -58 -92 -8 -94 -99 -93 -33 -31 -84 -28 -39 -105 -23 -76 -35 -71 -100 -102 -29 -86 -70 -30 -8 0 -109 1 -22 -24 -92 -21 -103 -127 -67 0 -68 -31 -71 -111 -26 -123 -39 -116 -15 -86 -85 -137 -127 -134 -145 -29 -123 -19 -43 -152 -122 -148 -129 -97 -39 -28 -49 -93 -110 -103 -130 1 -114 -146 -99 -128 -118 -32 -48 -115 -155 -26 -37 -65 -48 -71 -6 -137 -178 -111 -139 -127 -160 -172 -98 -38 -156 -11 -62 -187 -53 2 -117 -3 -31 -143 -41 -47 -169 -162 -158 -12 -69 -114 -180 -155 -125 -64 -176 -184 -202 -116 -74 -98 -205 -84 -152 -54 -102 -165 -138 -140 -180 -96 -98 -109 -81 -199 -137 -56 -74 -179 -175 -114 -124 -15 -234 -219 -51 -41 -144 -134 -161 -59 -128 -71 -22 -165 -222 -70 -65 -51 -43 -86 -198 -238 -119 -31 -195 -87 -102 -30 -73 -76 -153 -238 -8 -73 -63 -148 -42 -16 -228 -243 -235 -160 -107 -235 -29 -188 -202 -42 -215 -159 -134 -172 -263 -188 -124 -34 -206 -15 -138 -184 -20 -32 -271 -103 -203 -129 -177 -69 -107 -265 -68 -299 -161 -148 -182 0 -207 -106 -68 -92 -53 -52 -288 -3 -211 -143 -204 -126 -152 -106 -232 -153 -234 -62 -124 -131 -42 -297 -332 -188 -115 -100 -173 -52 -115 -296 -301 -312 -292 -2 -321 -178 -174 -244 -309 -161 -346 -251 -157 -325 -292 -159 -95 0 -124 -69 -324 -223 -89 -359 -242 -239 1 -39 -204 -287 -142 -123 -363 -218 -197 -136 -20 -304 -281 -83 -7 -129 -315 -76 -349 -141 -318 -369 -346 -161 -141 -110 -279 -5 -86 -348 -59 -255 -266 -355 -110 -14 -339 -109 -44 -38 -10 -164 -214 -265 -412 -72 -413 -271 -343 -124 -352 -304 -124 -381 -258 -8 -235 -288 -27 -296 -179 -392 -336 -255 -114 -15 -407 -296 -29 -352 -419 -190 -308 -2 -430 -157 -379 -220 -179 -77 -337 -61 -48 -64 -197 -408 -284 -84 -409 -243 -316 -77 -77 -428 -432 -182 -437 -254 -50 -260 -301 -28 -33 -335 -348 -240 -287 -436 -225 -221 -198 -190 -50 -87 -161 -408 0 -14 -225 -105 -188 -290 -349 -57 -45 -20 -384 -36 -264 -359 -52 -21 -328 -194 -432 -113 -475 -391 -86 -407 -18 -435 -206 -317 -254 -369 -373 -127 -405 -309 -154 -480 -271 -71 -306 -381 -252 -253 -420 -40 -349 -403 -44 -256 -33 -429 -10 -461 -405 -216 -329 -201 -498 -392 -149 -419 -85 -408 -248 -88 -322 -438 -381 -100 -445 -412 -215 -220 -83 -436 -411 -555 -372 -232 -309 -151 -214 -219 -268 -123 -90 -241 -508 -134 -74 -296 -505 -240 -161 -477 -63 -118 -293 -69 -197 -88 -520 -170 -37 -114 -234 -36 -225 -116 -36 -195 -363 -75 -137 -7 -506 -124 -556 -15 -327 -74 -367 -505 -29 -296 -281 -180 -420 -119 -449 -502 -204 -294 -484 -515 -74 -337 -256 -479 -471 -27 -614 -354 -369 -607 -244 -578 -195 -215 -407 -552 -247 -514 -434 -291 -521 -99 -598 -292 -400 -594 -381 -602 -260 -79 -441 -444 -146 -451 -502 -215 -81 -577 -652 -507 -264 -588 -431 -401 -103 -282 -125 -259 -615 -321 -271 -84 -84 -323 -650 -79 -289 -522 -129 -343 -441 -186 -561 -244 -186 -296 -272 -258 -308 -390 -677 -367 -186 -604 -104 -481 -394 -31 -663 -493 -608 -142 -86 -356 -581 -131 -11 -92 -258 -552 -176 -244 -208 -564 -9 -558 -256 -439 -460 -641 -457 -715 -328 -291 -172 -380 -406 0 -123 -286 -301 -375 -358 -607 -599 -670 -94 -143 -65 -201 -486 -394 -405 -671 -673 -564 -137 -200 -148 -644 -589 -643 -155 -714 -602 -54 -746 -403 -520 -446 -646 -680 -474 -431 -762 -712 -554 -187 -242 -242 -595 -66 -610 -378 -430 -595 -485 -467 -434 -663 -375 -81 -503 -688 -651 -17 -10 -184 -361 -165 -785 -61 -211 -140 -740 -126 -549 -222 -611 -557 -786 -525 -431 -111 -287 -131 -574 -212 -733 -223 -734 -275 -524 -295 -541 -240 -162 -750 -350 -486 -672 -579 -410 -737 -544 -728 -516 -163 -227 -249 -177 -522 -363 -190 -613 -148 -810 -593 -702 -545 -187 -27 -332 -611 -510 -214 -56 -219 -696 -593 -720 -479 -155 -278 -517 -691 -314 -638 -748 -232 -737 -46 -138 -192 -631 -224 -691 -628 -613 -324 -185 -365 -259 -219 -462 -290 -783 -710 -444 -271 -117 -469 -609 -105 -602 -465 -260 -323 -544 -493 -458 -261 -102 -198 -221 -321 -694 -614 -147 -511 -592 -335 -738 -198 -274 -780 -598 -281 -686 -25 -682 -827 -491 -312 -540 -304 -293 2 -238 -614 -22 -380 -194 -167 -167 -569 -170 -184 -104 -327 -401 -654 -926 -571 -181 -809 -552 -767 -579 -823 -620 -660 -853 -448 -720 -872 -898 -45 -154 -409 -399 -950 -393 -782 -376 -65 -644 -654 -523 -24 -767 -419 -183 -143 -98 -792 -485 -923 -360 -173 -879 -847 -732 -962 -643 -392 -117 -4 -932 -253 -298 -381 -339 -796 -274 -79 -586 -567 -425 -541 -329 -800 -878 -519 -111 -224 -304 -560 -183 -604 -952 -229 2 -115 -748 -262 -54 -533 -139 -785 -583 -634 -164 -836 -77 -578 -593 -561 -596 -611 -440 -27 -848 -998 -56 -947 -740 -737 -612 -655 -845 -812 -925 -197 -236 -37 -753 -747 -286 -641 -43 -348 -33 -713 -610 -777 -899 -1005 -264 -193 -928 -193 -412 -213 -228 -1012 -920 -702 -420 -496 -1019 -386 -645 -804 -795 -12 -810 -117 -454 -266 -1059 -321 -674 -647";

		private readonly string input6 = "2 8 8 5 4 2 3 1 5 5 1 2 15 13 5 14";

		private readonly string input10 = "46,41,212,83,1,255,157,65,139,52,39,254,2,86,0,204";

		public Advent2017() {
			Console.WriteLine("1.1: " + DayOne_1(input1));
			Console.WriteLine("1.2: " + DayOne_2(input1));
			Console.WriteLine("2.1: " + DayTwo_1(input2));
			Console.WriteLine("2.2: " + DayTwo_2(input2));
			Console.WriteLine("4.1: " + DayFour_1(input4));
			Console.WriteLine("4.2: " + DayFour_2(input4));
			Console.WriteLine("5.1: " + DayFive_1(input5));
			Console.WriteLine("5.2: " + DayFive_2(input5));
			Console.WriteLine("6.1: " + DaySix_1(input6));
			Console.WriteLine("6.2: " + DaySix_2(input6));
			Console.WriteLine("10.1: " + DayTen_1(input10));
			Console.WriteLine("10.2: " + DayTen_2(input10));
		}

		private long DayOne_1(string input) {
			long result = 0;
			for (int i = 0; i < input.Length; i++) {
				if (i == input.Length - 1) {
					if (input[i].Equals(input[0]))
					{
						result += int.Parse("" + input[i]);
					}
				}
				else
				{
					if (input[i].Equals(input[i + 1]))
					{
						var test = "" + input[i];
						result += int.Parse(test);
					}
				}

			}
			return result;
		}

		private long DayOne_2(string input)
		{
			int inputLength = input.Length;
			long result = 0;
			for (int i = 0; i < inputLength; i++)
			{
				int secondIndex = i + (inputLength / 2);
				if (secondIndex >= inputLength) {
					secondIndex -= inputLength;
				}
				if (input[i].Equals(input[secondIndex]))
				{
					result += int.Parse("" + input[i]);
				}

			}
			return result;
		}

		private long DayTwo_1(int[,] input)
		{
			List<List<int>> list = MakeList(input);
			long result = 0;
			for (int i = 0; i < list.Count; i++)
			{
				result += GetCheckSum(list[i]);
			}
			return result;
		}

		private long DayTwo_2(int[,] input)
		{
			List<List<int>> list = MakeList(input);
			long result = 0;
			for (int i = 0; i < list.Count; i++)
			{
				result += GetEvenDivisionSum(list[i]);
			}
			return result;
		}

		private int DayFour_1(string input)
		{
			bool foundInvalid = false;
			string[] passphrases = input.Split('-');
			int valids = passphrases.Count();
			foreach (string passphrase in passphrases) {
				string[] passWords = passphrase.Split(' ');
				for (int i = 0; i < passWords.Length; i++) {
					for (int j = 0; j < passWords.Length; j++)
					{
						if (i != j && passWords[i].Equals(passWords[j])) {
							foundInvalid = true;
							break;
						}
					}
					if (foundInvalid)
					{
						valids--;
						foundInvalid = false;
						break;
					}
				}
			}
			return valids;
		}

		private int DayFour_2(string input)
		{
			bool foundInvalid = false;
			string[] passphrases = input.Split('-');
			int valids = passphrases.Count();
			foreach (string passphrase in passphrases)
			{
				string[] passWords = passphrase.Split(' ');
				var sortedPassWords = new List<string>();
				foreach (string word in passWords) {
					sortedPassWords.Add(SortString(word));
				}

				for (int i = 0; i < sortedPassWords.Count; i++)
				{
					for (int j = 0; j < sortedPassWords.Count; j++)
					{
						if (i != j && sortedPassWords[i].Equals(sortedPassWords[j]))
						{
							foundInvalid = true;
							break;
						}
					}
					if (foundInvalid)
					{
						valids--;
						foundInvalid = false;
						break;
					}
				}
			}
			return valids;
		}

		private int DayFive_1(string input)
		{
			int steps = 0;
			int location = 0;
			bool escape = false;

			var maze = new List<int>();
			var inputArray = input.Split(' ');

			foreach (string s in inputArray) {
				maze.Add(int.Parse(s));
			}

			while (!escape) {
				maze[location]++;
				location += (maze[location] - 1);
				if (location >= maze.Count) {
					escape = true;
				}
				steps++;
			}
			return steps;
		}

		private int DayFive_2(string input)
		{
			int steps = 0;
			int location = 0;
			bool escape = false;

			var maze = new List<int>();
			var inputArray = input.Split(' ');

			foreach (string s in inputArray)
			{
				maze.Add(int.Parse(s));
			}

			while (!escape)
			{
				if (maze[location] >= 3)
				{
					maze[location]--;
					location += (maze[location] + 1);

				} else
				{
					maze[location]++;
					location += (maze[location] - 1);
				}
				if (location >= maze.Count)
				{
					escape = true;
				}
				steps++;
			}
			return steps;
		}

		private int DaySix_1(string input) {
			var stateList = new List<string>();
			int steps = 1;
			string tempState = "";

			var inputArray = input.Split(' ');
			var inputList = new List<int>();

			foreach (string s in inputArray) {
				inputList.Add(int.Parse(s));
			}

			tempState = string.Join(",", inputList.Select(n => n.ToString()).ToArray());
			stateList.Add(tempState);
			while (true) {
				inputList = Redistribute(inputList);
				tempState = string.Join(",", inputList.Select(n => n.ToString()).ToArray());
				if (stateList.Contains(tempState)) {
					break;
				} else {
					steps++;
					stateList.Add(tempState);
				}
			}

			return steps;
		}

		private int DaySix_2(string input)
		{
			var stateList = new List<string>();
			int steps = 1;
			string tempState = "";

			var inputArray = input.Split(' ');
			var inputList = new List<int>();

			foreach (string s in inputArray)
			{
				inputList.Add(int.Parse(s));
			}

			tempState = string.Join(",", inputList.Select(n => n.ToString()).ToArray());
			stateList.Add(tempState);
			while (true)
			{
				inputList = Redistribute(inputList);
				tempState = string.Join(",", inputList.Select(n => n.ToString()).ToArray());
				if (stateList.Contains(tempState))
				{
					break;
				}
				else
				{
					steps++;
					stateList.Add(tempState);
				}
			}

			string loopState = tempState;
			steps = 0;
			tempState = "";

			while (loopState != tempState) {
				inputList = Redistribute(inputList);
				tempState = string.Join(",", inputList.Select(n => n.ToString()).ToArray());
				steps++;
			}

			return steps;
		}

		private int DayTen_1(string input) {
			var numberList = CreateListOfNumbers(NUMBERLIST_SIZE);
			int pos = 0;
			int skipSize = 0;

			var inputArray = input.Split(',');
			var lengths = new List<int>();

			foreach (string s in inputArray)
			{
				lengths.Add(int.Parse(s));
			}

			foreach (int length in lengths) {
				if (length >= NUMBERLIST_SIZE) {
					continue;
				}
				numberList = ReverseAt(numberList, pos, length);
				pos += (length + skipSize);
				if (pos > NUMBERLIST_SIZE) {
					pos -= NUMBERLIST_SIZE;
				}
				skipSize++;
			}

			return numberList[0] * numberList[1];
		}

		private string DayTen_2(string input)
		{
			List<byte> numberList = CreateListOfNumbers(NUMBERLIST_SIZE);
			byte[] asciiBytes = Encoding.ASCII.GetBytes(input);
			List<byte> oldLengths = asciiBytes.ToList<byte>();
			byte[] numToAdd = { 17, 31, 73, 47, 23 };
			oldLengths = oldLengths.Concat<byte>(numToAdd).ToList();

			int pos = 0;
			int skipSize = 0;

			for (int i = 0; i < 64; i++)
			{
				var lengths = oldLengths;

				foreach (int length in lengths)
				{
					numberList = ReverseAt(numberList, pos, length);
					pos += (length + skipSize);
					skipSize++;
					while(pos >= NUMBERLIST_SIZE) {
						pos -= NUMBERLIST_SIZE;
					}
				}
			}

			List<byte> denseHash = GetDenseHash(numberList);

			string hexHash = "";
			string tempHex = "";
			foreach(byte b in denseHash) {
				tempHex = b.ToString("X");
				if (tempHex.Length == 1)
				{
					hexHash += "0";
				}
				
				hexHash += tempHex;				
			}

			return hexHash.ToLower();
		}

		private List<byte> GetDenseHash(List<byte> list) {
			var hashList = new List<byte>();
			byte tempNum = 0;
			for(int i = 0; i < list.Count; i++) {
				tempNum = (byte)(tempNum ^ list[i]);

				if((i + 1) % 16 == 0) {
					hashList.Add(tempNum);
					tempNum = 0;
				}
			}
			return hashList;
		}

		private List<byte> ReverseAt(List<byte> list, int pos, int length) {
			var tempList = new List<byte>();

			int currentPos = 0;
			for(int i = 0; i < length; i++) {
				currentPos = pos + i;
				while (currentPos >= list.Count) {
					currentPos -= list.Count;
				}
				tempList.Add(list[currentPos]);
			}

			tempList.Reverse();

			for (int i = 0; i < length; i++)
			{
				currentPos = pos + i;
				if (currentPos >= list.Count)
				{
					currentPos -= list.Count;
				}
				list[currentPos] = tempList[i];
			}

			return list;
		}

		private List<byte> CreateListOfNumbers(int max) {
			var list = new List<byte>();
			
			for(int i =  0; i < max; i++) {
				list.Add((byte)i);
			}

			return list;
		}

		private List<int> Redistribute(List<int> list) {
			int value = list.Max();
			int index = list.IndexOf(value);
			list[index] = 0;

			while(value > 0) {
				index++;
				if(index >= list.Count) {
					index -= list.Count;
				}
				list[index]++;
				value--;
			}

			return list;
		}

		private List<List<int>> MakeList(int[,] array)
		{
			var list = new List<List<int>>();
			for (int i = 0; i < array.GetLength(0); i++)
			{
				var tempList = new List<int>();
				for (int j = 0; j < array.GetLength(1); j++)
				{
					tempList.Add(array[i, j]);
				}
				list.Add(tempList);
			}
			return list;
		}

		private int GetCheckSum(List<int> list)
		{
			var biggestNumber = 0;
			var smallestNumber = 9999999;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] > biggestNumber)
				{
					biggestNumber = list[i];
				}
				if (list[i] < smallestNumber)
				{
					smallestNumber = list[i];
				}
			}
			return biggestNumber - smallestNumber;
		}

		private int GetEvenDivisionSum(List<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (list[i] % list[j] == 0 && list[i] / list[j] > 1)
					{
						return list[i] / list[j];
					}
				}
			}
			return 1;
		}

		private string SortString(string input)
		{
			char[] characters = input.ToArray();
			Array.Sort(characters);
			return new string(characters);
		}
	}
}
