# ------------------------------------------------------------------------------
# Copyright (c) 2007, 2008, 2009, 2010, 2011, 2012
# Ron MacNeil <macro@hotmail.com>
#
# Permission to use, copy, modify, and distribute this software for any
# purpose with or without fee is hereby granted, provided that the above
# copyright notice and this permission notice appear in all copies.
#
# THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
# WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
# MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
# ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
# WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
# ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
# OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
# ------------------------------------------------------------------------------


RULE_TARGET := $(RESBIAN_dotfile)
RULE_REQDBYS := $(RESBIAN_outfiles)
RULE_REQS := $(RESBIAN_srcs_abs)
RULE_REQS += $(call PROJ_GetVar,RUNNABLE_dotfile,$(RESBIAN_PROJ))
RULE_OREQ := $(RESBIAN_outdir)

define RULE_COMMANDS
	rm -rf $(call SYSTEM_ShellEscape,$(RESBIAN_outdir))/*

$(foreach c,$(RESBIAN_cultures),$(foreach t,$(call RESBIAN_GetTypes,$(c)),\
$(MAKE_CHAR_NEWLINE)	$(call PROJ_GetVar,RUNNABLE_run,$(RESBIAN_PROJ)) compile $(foreach f,$(call RESBIAN_GetFilesCT,$(c),$(t)) $(call MAKE_EncodeWord,$(call RESBIAN_GetOutfile,$(c),$(t))),$(call SYSTEM_ShellEscape,$(call RUNNABLE_ArgPathAbs,$(call MAKE_DecodeWord,$(f)),$(RESBIAN_PROJ))))\
))

	touch $(call SYSTEM_ShellEscape,$(RESBIAN_dotfile))
endef

$(call PROJ_Rule)

