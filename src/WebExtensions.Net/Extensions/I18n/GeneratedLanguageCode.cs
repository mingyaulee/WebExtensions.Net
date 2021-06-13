using System.Collections.Generic;

namespace WebExtensions.Net.I18n
{
    public partial class LanguageCode
    {
        private static readonly IDictionary<string, LanguageCode> LanguageDictionary = new Dictionary<string, LanguageCode>()
        {
            { "ENGLISH", new LanguageCode("en", "eng", null, "ENGLISH") },
            { "DANISH", new LanguageCode("da", "dan", null, "DANISH") },
            { "DUTCH", new LanguageCode("nl", "dut", null, "DUTCH") },
            { "FINNISH", new LanguageCode("fi", "fin", null, "FINNISH") },
            { "FRENCH", new LanguageCode("fr", "fre", null, "FRENCH") },
            { "GERMAN", new LanguageCode("de", "ger", null, "GERMAN") },
            { "HEBREW", new LanguageCode("he", "heb", null, "HEBREW") },
            { "ITALIAN", new LanguageCode("it", "ita", null, "ITALIAN") },
            { "Japanese", new LanguageCode("ja", "jpn", null, "Japanese") },
            { "Korean", new LanguageCode("ko", "kor", null, "Korean") },
            { "NORWEGIAN", new LanguageCode("nb", "nor", null, "NORWEGIAN") },
            { "POLISH", new LanguageCode("pl", "pol", null, "POLISH") },
            { "PORTUGUESE", new LanguageCode("pt", "por", null, "PORTUGUESE") },
            { "RUSSIAN", new LanguageCode("ru", "rus", null, "RUSSIAN") },
            { "SPANISH", new LanguageCode("es", "spa", null, "SPANISH") },
            { "SWEDISH", new LanguageCode("sv", "swe", null, "SWEDISH") },
            { "Chinese", new LanguageCode("zh", "chi", "zh-CN", "Chinese") },
            { "CZECH", new LanguageCode("cs", "cze", null, "CZECH") },
            { "GREEK", new LanguageCode("el", "gre", null, "GREEK") },
            { "ICELANDIC", new LanguageCode("is", "ice", null, "ICELANDIC") },
            { "LATVIAN", new LanguageCode("lv", "lav", null, "LATVIAN") },
            { "LITHUANIAN", new LanguageCode("lt", "lit", null, "LITHUANIAN") },
            { "ROMANIAN", new LanguageCode("ro", "rum", null, "ROMANIAN") },
            { "HUNGARIAN", new LanguageCode("hu", "hun", null, "HUNGARIAN") },
            { "ESTONIAN", new LanguageCode("et", "est", null, "ESTONIAN") },
            { "TG_UNKNOWN_LANGUAGE", new LanguageCode(null, null, "ut", "TG_UNKNOWN_LANGUAGE") },
            { "Unknown", new LanguageCode(null, null, "un", "Unknown") },
            { "BULGARIAN", new LanguageCode("bg", "bul", null, "BULGARIAN") },
            { "CROATIAN", new LanguageCode("hr", "scr", null, "CROATIAN") },
            { "SERBIAN", new LanguageCode("sr", "scc", null, "SERBIAN") },
            { "IRISH", new LanguageCode("ga", "gle", null, "IRISH") },
            { "GALICIAN", new LanguageCode("gl", "glg", null, "GALICIAN") },
            { "TAGALOG", new LanguageCode(null, "fil", null, "TAGALOG") },
            { "TURKISH", new LanguageCode("tr", "tur", null, "TURKISH") },
            { "UKRAINIAN", new LanguageCode("uk", "ukr", null, "UKRAINIAN") },
            { "HINDI", new LanguageCode("hi", "hin", null, "HINDI") },
            { "MACEDONIAN", new LanguageCode("mk", "mac", null, "MACEDONIAN") },
            { "BENGALI", new LanguageCode("bn", "ben", null, "BENGALI") },
            { "INDONESIAN", new LanguageCode("id", "ind", null, "INDONESIAN") },
            { "LATIN", new LanguageCode("la", "lat", null, "LATIN") },
            { "MALAY", new LanguageCode("ms", "may", null, "MALAY") },
            { "MALAYALAM", new LanguageCode("ml", "mal", null, "MALAYALAM") },
            { "WELSH", new LanguageCode("cy", "wel", null, "WELSH") },
            { "NEPALI", new LanguageCode("ne", "nep", null, "NEPALI") },
            { "TELUGU", new LanguageCode("te", "tel", null, "TELUGU") },
            { "ALBANIAN", new LanguageCode("sq", "alb", null, "ALBANIAN") },
            { "TAMIL", new LanguageCode("ta", "tam", null, "TAMIL") },
            { "BELARUSIAN", new LanguageCode("be", "bel", null, "BELARUSIAN") },
            { "JAVANESE", new LanguageCode("jw", "jav", null, "JAVANESE") },
            { "OCCITAN", new LanguageCode("oc", "oci", null, "OCCITAN") },
            { "URDU", new LanguageCode("ur", "urd", null, "URDU") },
            { "BIHARI", new LanguageCode("bh", "bih", null, "BIHARI") },
            { "GUJARATI", new LanguageCode("gu", "guj", null, "GUJARATI") },
            { "THAI", new LanguageCode("th", "tha", null, "THAI") },
            { "ARABIC", new LanguageCode("ar", "ara", null, "ARABIC") },
            { "CATALAN", new LanguageCode("ca", "cat", null, "CATALAN") },
            { "ESPERANTO", new LanguageCode("eo", "epo", null, "ESPERANTO") },
            { "BASQUE", new LanguageCode("eu", "baq", null, "BASQUE") },
            { "INTERLINGUA", new LanguageCode("ia", "ina", null, "INTERLINGUA") },
            { "KANNADA", new LanguageCode("kn", "kan", null, "KANNADA") },
            { "PUNJABI", new LanguageCode("pa", "pan", null, "PUNJABI") },
            { "SCOTS_GAELIC", new LanguageCode("gd", "gla", null, "SCOTS_GAELIC") },
            { "SWAHILI", new LanguageCode("sw", "swa", null, "SWAHILI") },
            { "SLOVENIAN", new LanguageCode("sl", "slv", null, "SLOVENIAN") },
            { "MARATHI", new LanguageCode("mr", "mar", null, "MARATHI") },
            { "MALTESE", new LanguageCode("mt", "mlt", null, "MALTESE") },
            { "VIETNAMESE", new LanguageCode("vi", "vie", null, "VIETNAMESE") },
            { "FRISIAN", new LanguageCode("fy", "fry", null, "FRISIAN") },
            { "SLOVAK", new LanguageCode("sk", "slo", null, "SLOVAK") },
            { "ChineseT", new LanguageCode(null, null, "zh-TW", "ChineseT") },
            { "FAROESE", new LanguageCode("fo", "fao", null, "FAROESE") },
            { "SUNDANESE", new LanguageCode("su", "sun", null, "SUNDANESE") },
            { "UZBEK", new LanguageCode("uz", "uzb", null, "UZBEK") },
            { "AMHARIC", new LanguageCode("am", "amh", null, "AMHARIC") },
            { "AZERBAIJANI", new LanguageCode("az", "aze", null, "AZERBAIJANI") },
            { "GEORGIAN", new LanguageCode("ka", "geo", null, "GEORGIAN") },
            { "TIGRINYA", new LanguageCode("ti", "tir", null, "TIGRINYA") },
            { "PERSIAN", new LanguageCode("fa", "per", null, "PERSIAN") },
            { "BOSNIAN", new LanguageCode("bs", "bos", null, "BOSNIAN") },
            { "SINHALESE", new LanguageCode("si", "sin", null, "SINHALESE") },
            { "NORWEGIAN_N", new LanguageCode("nn", "nno", null, "NORWEGIAN_N") },
            { "PORTUGUESE_P", new LanguageCode(null, null, "pt-PT", "PORTUGUESE_P") },
            { "PORTUGUESE_B", new LanguageCode(null, null, "pt-BR", "PORTUGUESE_B") },
            { "XHOSA", new LanguageCode("xh", "xho", null, "XHOSA") },
            { "ZULU", new LanguageCode("zu", "zul", null, "ZULU") },
            { "GUARANI", new LanguageCode("gn", "grn", null, "GUARANI") },
            { "SESOTHO", new LanguageCode("st", "sot", null, "SESOTHO") },
            { "TURKMEN", new LanguageCode("tk", "tuk", null, "TURKMEN") },
            { "KYRGYZ", new LanguageCode("ky", "kir", null, "KYRGYZ") },
            { "BRETON", new LanguageCode("br", "bre", null, "BRETON") },
            { "TWI", new LanguageCode("tw", "twi", null, "TWI") },
            { "YIDDISH", new LanguageCode("yi", "yid", null, "YIDDISH") },
            { "SERBO_CROATIAN", new LanguageCode("sh", null, null, "SERBO_CROATIAN") },
            { "SOMALI", new LanguageCode("so", "som", null, "SOMALI") },
            { "UIGHUR", new LanguageCode("ug", "uig", null, "UIGHUR") },
            { "KURDISH", new LanguageCode("ku", "kur", null, "KURDISH") },
            { "MONGOLIAN", new LanguageCode("mn", "mon", null, "MONGOLIAN") },
            { "ARMENIAN", new LanguageCode("hy", "arm", null, "ARMENIAN") },
            { "LAOTHIAN", new LanguageCode("lo", "lao", null, "LAOTHIAN") },
            { "SINDHI", new LanguageCode("sd", "snd", null, "SINDHI") },
            { "RHAETO_ROMANCE", new LanguageCode("rm", "roh", null, "RHAETO_ROMANCE") },
            { "AFRIKAANS", new LanguageCode("af", "afr", null, "AFRIKAANS") },
            { "LUXEMBOURGISH", new LanguageCode("lb", "ltz", null, "LUXEMBOURGISH") },
            { "BURMESE", new LanguageCode("my", "bur", null, "BURMESE") },
            { "KHMER", new LanguageCode("km", "khm", null, "KHMER") },
            { "TIBETAN", new LanguageCode("bo", "tib", null, "TIBETAN") },
            { "DHIVEHI", new LanguageCode("dv", "div", null, "DHIVEHI") },
            { "CHEROKEE", new LanguageCode(null, "chr", null, "CHEROKEE") },
            { "SYRIAC", new LanguageCode(null, "syr", null, "SYRIAC") },
            { "LIMBU", new LanguageCode(null, null, "sit-NP", "LIMBU") },
            { "ORIYA", new LanguageCode("or", "ori", null, "ORIYA") },
            { "ASSAMESE", new LanguageCode("as", "asm", null, "ASSAMESE") },
            { "CORSICAN", new LanguageCode("co", "cos", null, "CORSICAN") },
            { "INTERLINGUE", new LanguageCode("ie", "ine", null, "INTERLINGUE") },
            { "KAZAKH", new LanguageCode("kk", "kaz", null, "KAZAKH") },
            { "LINGALA", new LanguageCode("ln", "lin", null, "LINGALA") },
            { "MOLDAVIAN", new LanguageCode("mo", "mol", null, "MOLDAVIAN") },
            { "PASHTO", new LanguageCode("ps", "pus", null, "PASHTO") },
            { "QUECHUA", new LanguageCode("qu", "que", null, "QUECHUA") },
            { "SHONA", new LanguageCode("sn", "sna", null, "SHONA") },
            { "TAJIK", new LanguageCode("tg", "tgk", null, "TAJIK") },
            { "TATAR", new LanguageCode("tt", "tat", null, "TATAR") },
            { "TONGA", new LanguageCode("to", "tog", null, "TONGA") },
            { "YORUBA", new LanguageCode("yo", "yor", null, "YORUBA") },
            { "CREOLES_AND_PIDGINS_ENGLISH_BASED", new LanguageCode(null, "cpe", null, "CREOLES_AND_PIDGINS_ENGLISH_BASED") },
            { "CREOLES_AND_PIDGINS_FRENCH_BASED", new LanguageCode(null, "cpf", null, "CREOLES_AND_PIDGINS_FRENCH_BASED") },
            { "CREOLES_AND_PIDGINS_PORTUGUESE_BASED", new LanguageCode(null, "cpp", null, "CREOLES_AND_PIDGINS_PORTUGUESE_BASED") },
            { "CREOLES_AND_PIDGINS_OTHER", new LanguageCode(null, "crp", null, "CREOLES_AND_PIDGINS_OTHER") },
            { "MAORI", new LanguageCode("mi", "mao", null, "MAORI") },
            { "WOLOF", new LanguageCode("wo", "wol", null, "WOLOF") },
            { "ABKHAZIAN", new LanguageCode("ab", "abk", null, "ABKHAZIAN") },
            { "AFAR", new LanguageCode("aa", "aar", null, "AFAR") },
            { "AYMARA", new LanguageCode("ay", "aym", null, "AYMARA") },
            { "BASHKIR", new LanguageCode("ba", "bak", null, "BASHKIR") },
            { "BISLAMA", new LanguageCode("bi", "bis", null, "BISLAMA") },
            { "DZONGKHA", new LanguageCode("dz", "dzo", null, "DZONGKHA") },
            { "FIJIAN", new LanguageCode("fj", "fij", null, "FIJIAN") },
            { "GREENLANDIC", new LanguageCode("kl", "kal", null, "GREENLANDIC") },
            { "HAUSA", new LanguageCode("ha", "hau", null, "HAUSA") },
            { "HAITIAN_CREOLE", new LanguageCode("ht", null, null, "HAITIAN_CREOLE") },
            { "INUPIAK", new LanguageCode("ik", "ipk", null, "INUPIAK") },
            { "INUKTITUT", new LanguageCode("iu", "iku", null, "INUKTITUT") },
            { "KASHMIRI", new LanguageCode("ks", "kas", null, "KASHMIRI") },
            { "KINYARWANDA", new LanguageCode("rw", "kin", null, "KINYARWANDA") },
            { "MALAGASY", new LanguageCode("mg", "mlg", null, "MALAGASY") },
            { "NAURU", new LanguageCode("na", "nau", null, "NAURU") },
            { "OROMO", new LanguageCode("om", "orm", null, "OROMO") },
            { "RUNDI", new LanguageCode("rn", "run", null, "RUNDI") },
            { "SAMOAN", new LanguageCode("sm", "smo", null, "SAMOAN") },
            { "SANGO", new LanguageCode("sg", "sag", null, "SANGO") },
            { "SANSKRIT", new LanguageCode("sa", "san", null, "SANSKRIT") },
            { "SISWANT", new LanguageCode("ss", "ssw", null, "SISWANT") },
            { "TSONGA", new LanguageCode("ts", "tso", null, "TSONGA") },
            { "TSWANA", new LanguageCode("tn", "tsn", null, "TSWANA") },
            { "VOLAPUK", new LanguageCode("vo", "vol", null, "VOLAPUK") },
            { "ZHUANG", new LanguageCode("za", "zha", null, "ZHUANG") },
            { "KHASI", new LanguageCode(null, "kha", null, "KHASI") },
            { "SCOTS", new LanguageCode(null, "sco", null, "SCOTS") },
            { "GANDA", new LanguageCode("lg", "lug", null, "GANDA") },
            { "MANX", new LanguageCode("gv", "glv", null, "MANX") },
            { "MONTENEGRIN", new LanguageCode(null, null, "sr-ME", "MONTENEGRIN") },
            { "XX", new LanguageCode(null, null, "XX", "XX") }
        };

        /// <summary>Gets the language code that represents ENGLISH. Code1: "en", Code2: "eng", CodeOther: null</summary>
        public static LanguageCode ENGLISH => LanguageDictionary["ENGLISH"];
        /// <summary>Gets the language code that represents DANISH. Code1: "da", Code2: "dan", CodeOther: null</summary>
        public static LanguageCode DANISH => LanguageDictionary["DANISH"];
        /// <summary>Gets the language code that represents DUTCH. Code1: "nl", Code2: "dut", CodeOther: null</summary>
        public static LanguageCode DUTCH => LanguageDictionary["DUTCH"];
        /// <summary>Gets the language code that represents FINNISH. Code1: "fi", Code2: "fin", CodeOther: null</summary>
        public static LanguageCode FINNISH => LanguageDictionary["FINNISH"];
        /// <summary>Gets the language code that represents FRENCH. Code1: "fr", Code2: "fre", CodeOther: null</summary>
        public static LanguageCode FRENCH => LanguageDictionary["FRENCH"];
        /// <summary>Gets the language code that represents GERMAN. Code1: "de", Code2: "ger", CodeOther: null</summary>
        public static LanguageCode GERMAN => LanguageDictionary["GERMAN"];
        /// <summary>Gets the language code that represents HEBREW. Code1: "he", Code2: "heb", CodeOther: null</summary>
        public static LanguageCode HEBREW => LanguageDictionary["HEBREW"];
        /// <summary>Gets the language code that represents ITALIAN. Code1: "it", Code2: "ita", CodeOther: null</summary>
        public static LanguageCode ITALIAN => LanguageDictionary["ITALIAN"];
        /// <summary>Gets the language code that represents Japanese. Code1: "ja", Code2: "jpn", CodeOther: null</summary>
        public static LanguageCode JAPANESE => LanguageDictionary["Japanese"];
        /// <summary>Gets the language code that represents Korean. Code1: "ko", Code2: "kor", CodeOther: null</summary>
        public static LanguageCode KOREAN => LanguageDictionary["Korean"];
        /// <summary>Gets the language code that represents NORWEGIAN. Code1: "nb", Code2: "nor", CodeOther: null</summary>
        public static LanguageCode NORWEGIAN => LanguageDictionary["NORWEGIAN"];
        /// <summary>Gets the language code that represents POLISH. Code1: "pl", Code2: "pol", CodeOther: null</summary>
        public static LanguageCode POLISH => LanguageDictionary["POLISH"];
        /// <summary>Gets the language code that represents PORTUGUESE. Code1: "pt", Code2: "por", CodeOther: null</summary>
        public static LanguageCode PORTUGUESE => LanguageDictionary["PORTUGUESE"];
        /// <summary>Gets the language code that represents RUSSIAN. Code1: "ru", Code2: "rus", CodeOther: null</summary>
        public static LanguageCode RUSSIAN => LanguageDictionary["RUSSIAN"];
        /// <summary>Gets the language code that represents SPANISH. Code1: "es", Code2: "spa", CodeOther: null</summary>
        public static LanguageCode SPANISH => LanguageDictionary["SPANISH"];
        /// <summary>Gets the language code that represents SWEDISH. Code1: "sv", Code2: "swe", CodeOther: null</summary>
        public static LanguageCode SWEDISH => LanguageDictionary["SWEDISH"];
        /// <summary>Gets the language code that represents Chinese. Code1: "zh", Code2: "chi", CodeOther: "zh-CN"</summary>
        public static LanguageCode CHINESE => LanguageDictionary["Chinese"];
        /// <summary>Gets the language code that represents CZECH. Code1: "cs", Code2: "cze", CodeOther: null</summary>
        public static LanguageCode CZECH => LanguageDictionary["CZECH"];
        /// <summary>Gets the language code that represents GREEK. Code1: "el", Code2: "gre", CodeOther: null</summary>
        public static LanguageCode GREEK => LanguageDictionary["GREEK"];
        /// <summary>Gets the language code that represents ICELANDIC. Code1: "is", Code2: "ice", CodeOther: null</summary>
        public static LanguageCode ICELANDIC => LanguageDictionary["ICELANDIC"];
        /// <summary>Gets the language code that represents LATVIAN. Code1: "lv", Code2: "lav", CodeOther: null</summary>
        public static LanguageCode LATVIAN => LanguageDictionary["LATVIAN"];
        /// <summary>Gets the language code that represents LITHUANIAN. Code1: "lt", Code2: "lit", CodeOther: null</summary>
        public static LanguageCode LITHUANIAN => LanguageDictionary["LITHUANIAN"];
        /// <summary>Gets the language code that represents ROMANIAN. Code1: "ro", Code2: "rum", CodeOther: null</summary>
        public static LanguageCode ROMANIAN => LanguageDictionary["ROMANIAN"];
        /// <summary>Gets the language code that represents HUNGARIAN. Code1: "hu", Code2: "hun", CodeOther: null</summary>
        public static LanguageCode HUNGARIAN => LanguageDictionary["HUNGARIAN"];
        /// <summary>Gets the language code that represents ESTONIAN. Code1: "et", Code2: "est", CodeOther: null</summary>
        public static LanguageCode ESTONIAN => LanguageDictionary["ESTONIAN"];
        /// <summary>Gets the language code that represents TG_UNKNOWN_LANGUAGE. Code1: null, Code2: null, CodeOther: "ut"</summary>
        public static LanguageCode TG_UNKNOWN_LANGUAGE => LanguageDictionary["TG_UNKNOWN_LANGUAGE"];
        /// <summary>Gets the language code that represents Unknown. Code1: null, Code2: null, CodeOther: "un"</summary>
        public static LanguageCode UNKNOWN => LanguageDictionary["Unknown"];
        /// <summary>Gets the language code that represents BULGARIAN. Code1: "bg", Code2: "bul", CodeOther: null</summary>
        public static LanguageCode BULGARIAN => LanguageDictionary["BULGARIAN"];
        /// <summary>Gets the language code that represents CROATIAN. Code1: "hr", Code2: "scr", CodeOther: null</summary>
        public static LanguageCode CROATIAN => LanguageDictionary["CROATIAN"];
        /// <summary>Gets the language code that represents SERBIAN. Code1: "sr", Code2: "scc", CodeOther: null</summary>
        public static LanguageCode SERBIAN => LanguageDictionary["SERBIAN"];
        /// <summary>Gets the language code that represents IRISH. Code1: "ga", Code2: "gle", CodeOther: null</summary>
        public static LanguageCode IRISH => LanguageDictionary["IRISH"];
        /// <summary>Gets the language code that represents GALICIAN. Code1: "gl", Code2: "glg", CodeOther: null</summary>
        public static LanguageCode GALICIAN => LanguageDictionary["GALICIAN"];
        /// <summary>Gets the language code that represents TAGALOG. Code1: null, Code2: "fil", CodeOther: null</summary>
        public static LanguageCode TAGALOG => LanguageDictionary["TAGALOG"];
        /// <summary>Gets the language code that represents TURKISH. Code1: "tr", Code2: "tur", CodeOther: null</summary>
        public static LanguageCode TURKISH => LanguageDictionary["TURKISH"];
        /// <summary>Gets the language code that represents UKRAINIAN. Code1: "uk", Code2: "ukr", CodeOther: null</summary>
        public static LanguageCode UKRAINIAN => LanguageDictionary["UKRAINIAN"];
        /// <summary>Gets the language code that represents HINDI. Code1: "hi", Code2: "hin", CodeOther: null</summary>
        public static LanguageCode HINDI => LanguageDictionary["HINDI"];
        /// <summary>Gets the language code that represents MACEDONIAN. Code1: "mk", Code2: "mac", CodeOther: null</summary>
        public static LanguageCode MACEDONIAN => LanguageDictionary["MACEDONIAN"];
        /// <summary>Gets the language code that represents BENGALI. Code1: "bn", Code2: "ben", CodeOther: null</summary>
        public static LanguageCode BENGALI => LanguageDictionary["BENGALI"];
        /// <summary>Gets the language code that represents INDONESIAN. Code1: "id", Code2: "ind", CodeOther: null</summary>
        public static LanguageCode INDONESIAN => LanguageDictionary["INDONESIAN"];
        /// <summary>Gets the language code that represents LATIN. Code1: "la", Code2: "lat", CodeOther: null</summary>
        public static LanguageCode LATIN => LanguageDictionary["LATIN"];
        /// <summary>Gets the language code that represents MALAY. Code1: "ms", Code2: "may", CodeOther: null</summary>
        public static LanguageCode MALAY => LanguageDictionary["MALAY"];
        /// <summary>Gets the language code that represents MALAYALAM. Code1: "ml", Code2: "mal", CodeOther: null</summary>
        public static LanguageCode MALAYALAM => LanguageDictionary["MALAYALAM"];
        /// <summary>Gets the language code that represents WELSH. Code1: "cy", Code2: "wel", CodeOther: null</summary>
        public static LanguageCode WELSH => LanguageDictionary["WELSH"];
        /// <summary>Gets the language code that represents NEPALI. Code1: "ne", Code2: "nep", CodeOther: null</summary>
        public static LanguageCode NEPALI => LanguageDictionary["NEPALI"];
        /// <summary>Gets the language code that represents TELUGU. Code1: "te", Code2: "tel", CodeOther: null</summary>
        public static LanguageCode TELUGU => LanguageDictionary["TELUGU"];
        /// <summary>Gets the language code that represents ALBANIAN. Code1: "sq", Code2: "alb", CodeOther: null</summary>
        public static LanguageCode ALBANIAN => LanguageDictionary["ALBANIAN"];
        /// <summary>Gets the language code that represents TAMIL. Code1: "ta", Code2: "tam", CodeOther: null</summary>
        public static LanguageCode TAMIL => LanguageDictionary["TAMIL"];
        /// <summary>Gets the language code that represents BELARUSIAN. Code1: "be", Code2: "bel", CodeOther: null</summary>
        public static LanguageCode BELARUSIAN => LanguageDictionary["BELARUSIAN"];
        /// <summary>Gets the language code that represents JAVANESE. Code1: "jw", Code2: "jav", CodeOther: null</summary>
        public static LanguageCode JAVANESE => LanguageDictionary["JAVANESE"];
        /// <summary>Gets the language code that represents OCCITAN. Code1: "oc", Code2: "oci", CodeOther: null</summary>
        public static LanguageCode OCCITAN => LanguageDictionary["OCCITAN"];
        /// <summary>Gets the language code that represents URDU. Code1: "ur", Code2: "urd", CodeOther: null</summary>
        public static LanguageCode URDU => LanguageDictionary["URDU"];
        /// <summary>Gets the language code that represents BIHARI. Code1: "bh", Code2: "bih", CodeOther: null</summary>
        public static LanguageCode BIHARI => LanguageDictionary["BIHARI"];
        /// <summary>Gets the language code that represents GUJARATI. Code1: "gu", Code2: "guj", CodeOther: null</summary>
        public static LanguageCode GUJARATI => LanguageDictionary["GUJARATI"];
        /// <summary>Gets the language code that represents THAI. Code1: "th", Code2: "tha", CodeOther: null</summary>
        public static LanguageCode THAI => LanguageDictionary["THAI"];
        /// <summary>Gets the language code that represents ARABIC. Code1: "ar", Code2: "ara", CodeOther: null</summary>
        public static LanguageCode ARABIC => LanguageDictionary["ARABIC"];
        /// <summary>Gets the language code that represents CATALAN. Code1: "ca", Code2: "cat", CodeOther: null</summary>
        public static LanguageCode CATALAN => LanguageDictionary["CATALAN"];
        /// <summary>Gets the language code that represents ESPERANTO. Code1: "eo", Code2: "epo", CodeOther: null</summary>
        public static LanguageCode ESPERANTO => LanguageDictionary["ESPERANTO"];
        /// <summary>Gets the language code that represents BASQUE. Code1: "eu", Code2: "baq", CodeOther: null</summary>
        public static LanguageCode BASQUE => LanguageDictionary["BASQUE"];
        /// <summary>Gets the language code that represents INTERLINGUA. Code1: "ia", Code2: "ina", CodeOther: null</summary>
        public static LanguageCode INTERLINGUA => LanguageDictionary["INTERLINGUA"];
        /// <summary>Gets the language code that represents KANNADA. Code1: "kn", Code2: "kan", CodeOther: null</summary>
        public static LanguageCode KANNADA => LanguageDictionary["KANNADA"];
        /// <summary>Gets the language code that represents PUNJABI. Code1: "pa", Code2: "pan", CodeOther: null</summary>
        public static LanguageCode PUNJABI => LanguageDictionary["PUNJABI"];
        /// <summary>Gets the language code that represents SCOTS_GAELIC. Code1: "gd", Code2: "gla", CodeOther: null</summary>
        public static LanguageCode SCOTS_GAELIC => LanguageDictionary["SCOTS_GAELIC"];
        /// <summary>Gets the language code that represents SWAHILI. Code1: "sw", Code2: "swa", CodeOther: null</summary>
        public static LanguageCode SWAHILI => LanguageDictionary["SWAHILI"];
        /// <summary>Gets the language code that represents SLOVENIAN. Code1: "sl", Code2: "slv", CodeOther: null</summary>
        public static LanguageCode SLOVENIAN => LanguageDictionary["SLOVENIAN"];
        /// <summary>Gets the language code that represents MARATHI. Code1: "mr", Code2: "mar", CodeOther: null</summary>
        public static LanguageCode MARATHI => LanguageDictionary["MARATHI"];
        /// <summary>Gets the language code that represents MALTESE. Code1: "mt", Code2: "mlt", CodeOther: null</summary>
        public static LanguageCode MALTESE => LanguageDictionary["MALTESE"];
        /// <summary>Gets the language code that represents VIETNAMESE. Code1: "vi", Code2: "vie", CodeOther: null</summary>
        public static LanguageCode VIETNAMESE => LanguageDictionary["VIETNAMESE"];
        /// <summary>Gets the language code that represents FRISIAN. Code1: "fy", Code2: "fry", CodeOther: null</summary>
        public static LanguageCode FRISIAN => LanguageDictionary["FRISIAN"];
        /// <summary>Gets the language code that represents SLOVAK. Code1: "sk", Code2: "slo", CodeOther: null</summary>
        public static LanguageCode SLOVAK => LanguageDictionary["SLOVAK"];
        /// <summary>Gets the language code that represents ChineseT. Code1: null, Code2: null, CodeOther: "zh-TW"</summary>
        public static LanguageCode CHINESE_T => LanguageDictionary["ChineseT"];
        /// <summary>Gets the language code that represents FAROESE. Code1: "fo", Code2: "fao", CodeOther: null</summary>
        public static LanguageCode FAROESE => LanguageDictionary["FAROESE"];
        /// <summary>Gets the language code that represents SUNDANESE. Code1: "su", Code2: "sun", CodeOther: null</summary>
        public static LanguageCode SUNDANESE => LanguageDictionary["SUNDANESE"];
        /// <summary>Gets the language code that represents UZBEK. Code1: "uz", Code2: "uzb", CodeOther: null</summary>
        public static LanguageCode UZBEK => LanguageDictionary["UZBEK"];
        /// <summary>Gets the language code that represents AMHARIC. Code1: "am", Code2: "amh", CodeOther: null</summary>
        public static LanguageCode AMHARIC => LanguageDictionary["AMHARIC"];
        /// <summary>Gets the language code that represents AZERBAIJANI. Code1: "az", Code2: "aze", CodeOther: null</summary>
        public static LanguageCode AZERBAIJANI => LanguageDictionary["AZERBAIJANI"];
        /// <summary>Gets the language code that represents GEORGIAN. Code1: "ka", Code2: "geo", CodeOther: null</summary>
        public static LanguageCode GEORGIAN => LanguageDictionary["GEORGIAN"];
        /// <summary>Gets the language code that represents TIGRINYA. Code1: "ti", Code2: "tir", CodeOther: null</summary>
        public static LanguageCode TIGRINYA => LanguageDictionary["TIGRINYA"];
        /// <summary>Gets the language code that represents PERSIAN. Code1: "fa", Code2: "per", CodeOther: null</summary>
        public static LanguageCode PERSIAN => LanguageDictionary["PERSIAN"];
        /// <summary>Gets the language code that represents BOSNIAN. Code1: "bs", Code2: "bos", CodeOther: null</summary>
        public static LanguageCode BOSNIAN => LanguageDictionary["BOSNIAN"];
        /// <summary>Gets the language code that represents SINHALESE. Code1: "si", Code2: "sin", CodeOther: null</summary>
        public static LanguageCode SINHALESE => LanguageDictionary["SINHALESE"];
        /// <summary>Gets the language code that represents NORWEGIAN_N. Code1: "nn", Code2: "nno", CodeOther: null</summary>
        public static LanguageCode NORWEGIAN_N => LanguageDictionary["NORWEGIAN_N"];
        /// <summary>Gets the language code that represents PORTUGUESE_P. Code1: null, Code2: null, CodeOther: "pt-PT"</summary>
        public static LanguageCode PORTUGUESE_P => LanguageDictionary["PORTUGUESE_P"];
        /// <summary>Gets the language code that represents PORTUGUESE_B. Code1: null, Code2: null, CodeOther: "pt-BR"</summary>
        public static LanguageCode PORTUGUESE_B => LanguageDictionary["PORTUGUESE_B"];
        /// <summary>Gets the language code that represents XHOSA. Code1: "xh", Code2: "xho", CodeOther: null</summary>
        public static LanguageCode XHOSA => LanguageDictionary["XHOSA"];
        /// <summary>Gets the language code that represents ZULU. Code1: "zu", Code2: "zul", CodeOther: null</summary>
        public static LanguageCode ZULU => LanguageDictionary["ZULU"];
        /// <summary>Gets the language code that represents GUARANI. Code1: "gn", Code2: "grn", CodeOther: null</summary>
        public static LanguageCode GUARANI => LanguageDictionary["GUARANI"];
        /// <summary>Gets the language code that represents SESOTHO. Code1: "st", Code2: "sot", CodeOther: null</summary>
        public static LanguageCode SESOTHO => LanguageDictionary["SESOTHO"];
        /// <summary>Gets the language code that represents TURKMEN. Code1: "tk", Code2: "tuk", CodeOther: null</summary>
        public static LanguageCode TURKMEN => LanguageDictionary["TURKMEN"];
        /// <summary>Gets the language code that represents KYRGYZ. Code1: "ky", Code2: "kir", CodeOther: null</summary>
        public static LanguageCode KYRGYZ => LanguageDictionary["KYRGYZ"];
        /// <summary>Gets the language code that represents BRETON. Code1: "br", Code2: "bre", CodeOther: null</summary>
        public static LanguageCode BRETON => LanguageDictionary["BRETON"];
        /// <summary>Gets the language code that represents TWI. Code1: "tw", Code2: "twi", CodeOther: null</summary>
        public static LanguageCode TWI => LanguageDictionary["TWI"];
        /// <summary>Gets the language code that represents YIDDISH. Code1: "yi", Code2: "yid", CodeOther: null</summary>
        public static LanguageCode YIDDISH => LanguageDictionary["YIDDISH"];
        /// <summary>Gets the language code that represents SERBO_CROATIAN. Code1: "sh", Code2: null, CodeOther: null</summary>
        public static LanguageCode SERBO_CROATIAN => LanguageDictionary["SERBO_CROATIAN"];
        /// <summary>Gets the language code that represents SOMALI. Code1: "so", Code2: "som", CodeOther: null</summary>
        public static LanguageCode SOMALI => LanguageDictionary["SOMALI"];
        /// <summary>Gets the language code that represents UIGHUR. Code1: "ug", Code2: "uig", CodeOther: null</summary>
        public static LanguageCode UIGHUR => LanguageDictionary["UIGHUR"];
        /// <summary>Gets the language code that represents KURDISH. Code1: "ku", Code2: "kur", CodeOther: null</summary>
        public static LanguageCode KURDISH => LanguageDictionary["KURDISH"];
        /// <summary>Gets the language code that represents MONGOLIAN. Code1: "mn", Code2: "mon", CodeOther: null</summary>
        public static LanguageCode MONGOLIAN => LanguageDictionary["MONGOLIAN"];
        /// <summary>Gets the language code that represents ARMENIAN. Code1: "hy", Code2: "arm", CodeOther: null</summary>
        public static LanguageCode ARMENIAN => LanguageDictionary["ARMENIAN"];
        /// <summary>Gets the language code that represents LAOTHIAN. Code1: "lo", Code2: "lao", CodeOther: null</summary>
        public static LanguageCode LAOTHIAN => LanguageDictionary["LAOTHIAN"];
        /// <summary>Gets the language code that represents SINDHI. Code1: "sd", Code2: "snd", CodeOther: null</summary>
        public static LanguageCode SINDHI => LanguageDictionary["SINDHI"];
        /// <summary>Gets the language code that represents RHAETO_ROMANCE. Code1: "rm", Code2: "roh", CodeOther: null</summary>
        public static LanguageCode RHAETO_ROMANCE => LanguageDictionary["RHAETO_ROMANCE"];
        /// <summary>Gets the language code that represents AFRIKAANS. Code1: "af", Code2: "afr", CodeOther: null</summary>
        public static LanguageCode AFRIKAANS => LanguageDictionary["AFRIKAANS"];
        /// <summary>Gets the language code that represents LUXEMBOURGISH. Code1: "lb", Code2: "ltz", CodeOther: null</summary>
        public static LanguageCode LUXEMBOURGISH => LanguageDictionary["LUXEMBOURGISH"];
        /// <summary>Gets the language code that represents BURMESE. Code1: "my", Code2: "bur", CodeOther: null</summary>
        public static LanguageCode BURMESE => LanguageDictionary["BURMESE"];
        /// <summary>Gets the language code that represents KHMER. Code1: "km", Code2: "khm", CodeOther: null</summary>
        public static LanguageCode KHMER => LanguageDictionary["KHMER"];
        /// <summary>Gets the language code that represents TIBETAN. Code1: "bo", Code2: "tib", CodeOther: null</summary>
        public static LanguageCode TIBETAN => LanguageDictionary["TIBETAN"];
        /// <summary>Gets the language code that represents DHIVEHI. Code1: "dv", Code2: "div", CodeOther: null</summary>
        public static LanguageCode DHIVEHI => LanguageDictionary["DHIVEHI"];
        /// <summary>Gets the language code that represents CHEROKEE. Code1: null, Code2: "chr", CodeOther: null</summary>
        public static LanguageCode CHEROKEE => LanguageDictionary["CHEROKEE"];
        /// <summary>Gets the language code that represents SYRIAC. Code1: null, Code2: "syr", CodeOther: null</summary>
        public static LanguageCode SYRIAC => LanguageDictionary["SYRIAC"];
        /// <summary>Gets the language code that represents LIMBU. Code1: null, Code2: null, CodeOther: "sit-NP"</summary>
        public static LanguageCode LIMBU => LanguageDictionary["LIMBU"];
        /// <summary>Gets the language code that represents ORIYA. Code1: "or", Code2: "ori", CodeOther: null</summary>
        public static LanguageCode ORIYA => LanguageDictionary["ORIYA"];
        /// <summary>Gets the language code that represents ASSAMESE. Code1: "as", Code2: "asm", CodeOther: null</summary>
        public static LanguageCode ASSAMESE => LanguageDictionary["ASSAMESE"];
        /// <summary>Gets the language code that represents CORSICAN. Code1: "co", Code2: "cos", CodeOther: null</summary>
        public static LanguageCode CORSICAN => LanguageDictionary["CORSICAN"];
        /// <summary>Gets the language code that represents INTERLINGUE. Code1: "ie", Code2: "ine", CodeOther: null</summary>
        public static LanguageCode INTERLINGUE => LanguageDictionary["INTERLINGUE"];
        /// <summary>Gets the language code that represents KAZAKH. Code1: "kk", Code2: "kaz", CodeOther: null</summary>
        public static LanguageCode KAZAKH => LanguageDictionary["KAZAKH"];
        /// <summary>Gets the language code that represents LINGALA. Code1: "ln", Code2: "lin", CodeOther: null</summary>
        public static LanguageCode LINGALA => LanguageDictionary["LINGALA"];
        /// <summary>Gets the language code that represents MOLDAVIAN. Code1: "mo", Code2: "mol", CodeOther: null</summary>
        public static LanguageCode MOLDAVIAN => LanguageDictionary["MOLDAVIAN"];
        /// <summary>Gets the language code that represents PASHTO. Code1: "ps", Code2: "pus", CodeOther: null</summary>
        public static LanguageCode PASHTO => LanguageDictionary["PASHTO"];
        /// <summary>Gets the language code that represents QUECHUA. Code1: "qu", Code2: "que", CodeOther: null</summary>
        public static LanguageCode QUECHUA => LanguageDictionary["QUECHUA"];
        /// <summary>Gets the language code that represents SHONA. Code1: "sn", Code2: "sna", CodeOther: null</summary>
        public static LanguageCode SHONA => LanguageDictionary["SHONA"];
        /// <summary>Gets the language code that represents TAJIK. Code1: "tg", Code2: "tgk", CodeOther: null</summary>
        public static LanguageCode TAJIK => LanguageDictionary["TAJIK"];
        /// <summary>Gets the language code that represents TATAR. Code1: "tt", Code2: "tat", CodeOther: null</summary>
        public static LanguageCode TATAR => LanguageDictionary["TATAR"];
        /// <summary>Gets the language code that represents TONGA. Code1: "to", Code2: "tog", CodeOther: null</summary>
        public static LanguageCode TONGA => LanguageDictionary["TONGA"];
        /// <summary>Gets the language code that represents YORUBA. Code1: "yo", Code2: "yor", CodeOther: null</summary>
        public static LanguageCode YORUBA => LanguageDictionary["YORUBA"];
        /// <summary>Gets the language code that represents CREOLES_AND_PIDGINS_ENGLISH_BASED. Code1: null, Code2: "cpe", CodeOther: null</summary>
        public static LanguageCode CREOLES_AND_PIDGINS_ENGLISH_BASED => LanguageDictionary["CREOLES_AND_PIDGINS_ENGLISH_BASED"];
        /// <summary>Gets the language code that represents CREOLES_AND_PIDGINS_FRENCH_BASED. Code1: null, Code2: "cpf", CodeOther: null</summary>
        public static LanguageCode CREOLES_AND_PIDGINS_FRENCH_BASED => LanguageDictionary["CREOLES_AND_PIDGINS_FRENCH_BASED"];
        /// <summary>Gets the language code that represents CREOLES_AND_PIDGINS_PORTUGUESE_BASED. Code1: null, Code2: "cpp", CodeOther: null</summary>
        public static LanguageCode CREOLES_AND_PIDGINS_PORTUGUESE_BASED => LanguageDictionary["CREOLES_AND_PIDGINS_PORTUGUESE_BASED"];
        /// <summary>Gets the language code that represents CREOLES_AND_PIDGINS_OTHER. Code1: null, Code2: "crp", CodeOther: null</summary>
        public static LanguageCode CREOLES_AND_PIDGINS_OTHER => LanguageDictionary["CREOLES_AND_PIDGINS_OTHER"];
        /// <summary>Gets the language code that represents MAORI. Code1: "mi", Code2: "mao", CodeOther: null</summary>
        public static LanguageCode MAORI => LanguageDictionary["MAORI"];
        /// <summary>Gets the language code that represents WOLOF. Code1: "wo", Code2: "wol", CodeOther: null</summary>
        public static LanguageCode WOLOF => LanguageDictionary["WOLOF"];
        /// <summary>Gets the language code that represents ABKHAZIAN. Code1: "ab", Code2: "abk", CodeOther: null</summary>
        public static LanguageCode ABKHAZIAN => LanguageDictionary["ABKHAZIAN"];
        /// <summary>Gets the language code that represents AFAR. Code1: "aa", Code2: "aar", CodeOther: null</summary>
        public static LanguageCode AFAR => LanguageDictionary["AFAR"];
        /// <summary>Gets the language code that represents AYMARA. Code1: "ay", Code2: "aym", CodeOther: null</summary>
        public static LanguageCode AYMARA => LanguageDictionary["AYMARA"];
        /// <summary>Gets the language code that represents BASHKIR. Code1: "ba", Code2: "bak", CodeOther: null</summary>
        public static LanguageCode BASHKIR => LanguageDictionary["BASHKIR"];
        /// <summary>Gets the language code that represents BISLAMA. Code1: "bi", Code2: "bis", CodeOther: null</summary>
        public static LanguageCode BISLAMA => LanguageDictionary["BISLAMA"];
        /// <summary>Gets the language code that represents DZONGKHA. Code1: "dz", Code2: "dzo", CodeOther: null</summary>
        public static LanguageCode DZONGKHA => LanguageDictionary["DZONGKHA"];
        /// <summary>Gets the language code that represents FIJIAN. Code1: "fj", Code2: "fij", CodeOther: null</summary>
        public static LanguageCode FIJIAN => LanguageDictionary["FIJIAN"];
        /// <summary>Gets the language code that represents GREENLANDIC. Code1: "kl", Code2: "kal", CodeOther: null</summary>
        public static LanguageCode GREENLANDIC => LanguageDictionary["GREENLANDIC"];
        /// <summary>Gets the language code that represents HAUSA. Code1: "ha", Code2: "hau", CodeOther: null</summary>
        public static LanguageCode HAUSA => LanguageDictionary["HAUSA"];
        /// <summary>Gets the language code that represents HAITIAN_CREOLE. Code1: "ht", Code2: null, CodeOther: null</summary>
        public static LanguageCode HAITIAN_CREOLE => LanguageDictionary["HAITIAN_CREOLE"];
        /// <summary>Gets the language code that represents INUPIAK. Code1: "ik", Code2: "ipk", CodeOther: null</summary>
        public static LanguageCode INUPIAK => LanguageDictionary["INUPIAK"];
        /// <summary>Gets the language code that represents INUKTITUT. Code1: "iu", Code2: "iku", CodeOther: null</summary>
        public static LanguageCode INUKTITUT => LanguageDictionary["INUKTITUT"];
        /// <summary>Gets the language code that represents KASHMIRI. Code1: "ks", Code2: "kas", CodeOther: null</summary>
        public static LanguageCode KASHMIRI => LanguageDictionary["KASHMIRI"];
        /// <summary>Gets the language code that represents KINYARWANDA. Code1: "rw", Code2: "kin", CodeOther: null</summary>
        public static LanguageCode KINYARWANDA => LanguageDictionary["KINYARWANDA"];
        /// <summary>Gets the language code that represents MALAGASY. Code1: "mg", Code2: "mlg", CodeOther: null</summary>
        public static LanguageCode MALAGASY => LanguageDictionary["MALAGASY"];
        /// <summary>Gets the language code that represents NAURU. Code1: "na", Code2: "nau", CodeOther: null</summary>
        public static LanguageCode NAURU => LanguageDictionary["NAURU"];
        /// <summary>Gets the language code that represents OROMO. Code1: "om", Code2: "orm", CodeOther: null</summary>
        public static LanguageCode OROMO => LanguageDictionary["OROMO"];
        /// <summary>Gets the language code that represents RUNDI. Code1: "rn", Code2: "run", CodeOther: null</summary>
        public static LanguageCode RUNDI => LanguageDictionary["RUNDI"];
        /// <summary>Gets the language code that represents SAMOAN. Code1: "sm", Code2: "smo", CodeOther: null</summary>
        public static LanguageCode SAMOAN => LanguageDictionary["SAMOAN"];
        /// <summary>Gets the language code that represents SANGO. Code1: "sg", Code2: "sag", CodeOther: null</summary>
        public static LanguageCode SANGO => LanguageDictionary["SANGO"];
        /// <summary>Gets the language code that represents SANSKRIT. Code1: "sa", Code2: "san", CodeOther: null</summary>
        public static LanguageCode SANSKRIT => LanguageDictionary["SANSKRIT"];
        /// <summary>Gets the language code that represents SISWANT. Code1: "ss", Code2: "ssw", CodeOther: null</summary>
        public static LanguageCode SISWANT => LanguageDictionary["SISWANT"];
        /// <summary>Gets the language code that represents TSONGA. Code1: "ts", Code2: "tso", CodeOther: null</summary>
        public static LanguageCode TSONGA => LanguageDictionary["TSONGA"];
        /// <summary>Gets the language code that represents TSWANA. Code1: "tn", Code2: "tsn", CodeOther: null</summary>
        public static LanguageCode TSWANA => LanguageDictionary["TSWANA"];
        /// <summary>Gets the language code that represents VOLAPUK. Code1: "vo", Code2: "vol", CodeOther: null</summary>
        public static LanguageCode VOLAPUK => LanguageDictionary["VOLAPUK"];
        /// <summary>Gets the language code that represents ZHUANG. Code1: "za", Code2: "zha", CodeOther: null</summary>
        public static LanguageCode ZHUANG => LanguageDictionary["ZHUANG"];
        /// <summary>Gets the language code that represents KHASI. Code1: null, Code2: "kha", CodeOther: null</summary>
        public static LanguageCode KHASI => LanguageDictionary["KHASI"];
        /// <summary>Gets the language code that represents SCOTS. Code1: null, Code2: "sco", CodeOther: null</summary>
        public static LanguageCode SCOTS => LanguageDictionary["SCOTS"];
        /// <summary>Gets the language code that represents GANDA. Code1: "lg", Code2: "lug", CodeOther: null</summary>
        public static LanguageCode GANDA => LanguageDictionary["GANDA"];
        /// <summary>Gets the language code that represents MANX. Code1: "gv", Code2: "glv", CodeOther: null</summary>
        public static LanguageCode MANX => LanguageDictionary["MANX"];
        /// <summary>Gets the language code that represents MONTENEGRIN. Code1: null, Code2: null, CodeOther: "sr-ME"</summary>
        public static LanguageCode MONTENEGRIN => LanguageDictionary["MONTENEGRIN"];
        /// <summary>Gets the language code that represents XX. Code1: null, Code2: null, CodeOther: "XX"</summary>
        public static LanguageCode XX => LanguageDictionary["XX"];
    }
}
